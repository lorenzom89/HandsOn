using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class FlightClassRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<FlightClass>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var flightClass = await appDbContext.FlightClasses.FindAsync(id);
            if (flightClass is null) return NotFound();

            appDbContext.FlightClasses.Remove(flightClass);
            await Commit();
            return Success();
        }

        public async Task<List<FlightClass>> GetAll() => await appDbContext.FlightClasses.AsNoTracking().Include(f => f.Flight).ToListAsync();

        public async Task<FlightClass> GetById(int id) => await appDbContext.FlightClasses.FindAsync(id);


        public async Task<GeneralResponse> Insert(FlightClass item)
        {
            if (!await CheckNameAndFlight(item.Name!, item.FlightId!)) return new GeneralResponse(false, "Classe já cadastrada neste vôo");
            appDbContext.FlightClasses.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(FlightClass item)
        {
            var flightClass = await appDbContext.FlightClasses.FindAsync(item.Id);
            if (flightClass is null) return NotFound();

            flightClass.Name = item.Name;
            flightClass.SeatQuantity = item.SeatQuantity;
            flightClass.SeatPrice = item.SeatPrice;
            flightClass.FlightId = item.FlightId;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Desculpe, Classe não encontrada");
        private static GeneralResponse Success() => new(true, "Processo concluído");
        private async Task Commit() => await appDbContext.SaveChangesAsync();


        private async Task<bool> CheckNameAndFlight(string name, int flightId)
        {
            var item = await appDbContext.FlightClasses.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()) && x.FlightId!.Equals(flightId));
            return item is null;
        }
    }
}
