using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class FlightRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Flight>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var flight = await appDbContext.Flights.FindAsync(id);
            if (flight is null) return NotFound();

            appDbContext.Flights.Remove(flight);
            await Commit();
            return Success();
        }

        public async Task<List<Flight>> GetAll() => await appDbContext.Flights.ToListAsync();

        public async Task<Flight> GetById(int id) => await appDbContext.Flights.FindAsync(id);


        public async Task<GeneralResponse> Insert(Flight item)
        {
            if (!await CheckSearchCode(item.SearchCode!)) return new GeneralResponse(false, "Vôo já cadastrado");
            appDbContext.Flights.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Flight item)
        {
            var flight = await appDbContext.Flights.FindAsync(item.Id);
            if (flight is null) return NotFound();

            flight.SearchCode = item.SearchCode;
            flight.OriginAirportId = item.OriginAirportId;
            flight.DestinyAirportId = item.DestinyAirportId;
            flight.FlightTime = item.FlightTime;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Desculpe, Vôo não encontrado");
        private static GeneralResponse Success() => new(true, "Processo concluído");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private async Task<bool> CheckSearchCode(string searchCode)
        {
            var item = await appDbContext.Flights.FirstOrDefaultAsync(x => x.SearchCode!.ToLower().Equals(searchCode.ToLower()));
            return item is null;
        }
    }
}
