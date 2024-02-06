using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class AirportRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Airport>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var airport = await appDbContext.Airports.FindAsync(id);
            if (airport is null) return NotFound();

            appDbContext.Airports.Remove(airport);
            await Commit();
            return Success();
        }

        public async Task<List<Airport>> GetAll() => await appDbContext.Airports.ToListAsync();

        public async Task<Airport> GetById(int id) => await appDbContext.Airports.FindAsync(id);


        public async Task<GeneralResponse> Insert(Airport item)
        {
            if (!await CheckIATA(item.CodIATA!)) return new GeneralResponse(false, "Aeroporto já cadastrado");
            appDbContext.Airports.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Airport item)
        {
            var airport = await appDbContext.Airports.FindAsync(item.Id);
            if (airport is null) return NotFound();

            airport.Name = item.Name;
            airport.CityId = item.CityId;
            airport.CodIATA = item.CodIATA;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Desculpe, Aeroporto não encontrado");
        private static GeneralResponse Success() => new(true, "Processo concluído");
        private async Task Commit() => await appDbContext.SaveChangesAsync();


        private async Task<bool> CheckIATA(string iata)
        {
            var item = await appDbContext.Airports.FirstOrDefaultAsync(x => x.CodIATA!.ToLower().Equals(iata.ToLower()));
            return item is null;
        }
    }
}
