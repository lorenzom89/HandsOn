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

        public async Task<List<Flight>> GetAll() => await appDbContext.Flights.AsNoTracking().Include(a => a.OriginAirport).Include(a => a.DestinyAirport)
            .Include(a => a.OriginAirport!.City).Include(a => a.DestinyAirport!.City).ToListAsync();

        public async Task<Flight> GetById(int id) => await appDbContext.Flights.FindAsync(id);


        public async Task<GeneralResponse> Insert(Flight item)
        {
            if (!await CheckSearchCode(item.SearchCode!)) return new GeneralResponse(false, "Vôo já cadastrado");
            item.FlightTime = item.FlightTime.ToUniversalTime();
            var equalAirport = await CheckAirportCity(item);
            if (equalAirport) return SameAirportCity();
            if (CheckFlightTime(item))return InvalidFlightTime();

            item.OriginAirport = null; 
            item.DestinyAirport = null;
            appDbContext.Flights.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Flight item)
        {
            var flight = await appDbContext.Flights.FindAsync(item.Id);
            if (flight is null) return NotFound();
            var equalAirport = await CheckAirportCity(flight);
            if (equalAirport)
                return SameAirportCity();
            if (CheckFlightTime(flight))
                return InvalidFlightTime();


            flight.SearchCode = item.SearchCode;
            flight.OriginAirportId = item.OriginAirportId;
            flight.DestinyAirportId = item.DestinyAirportId;
            flight.FlightTime = item.FlightTime.ToUniversalTime();
            await Commit();
            return Success();
        }

        private static GeneralResponse SameAirportCity() => new(false, "Aeroportos de Origem e Destino não podem ser da mesma cidade");
        private static GeneralResponse InvalidFlightTime() => new(false, "O horário do vôo não pode ser anterior ao horário atual");

        private static GeneralResponse NotFound() => new(false, "Desculpe, Vôo não encontrado");
        private static GeneralResponse Success() => new(true, "Processo concluído");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private async Task<bool> CheckSearchCode(string searchCode)
        {
            var item = await appDbContext.Flights.FirstOrDefaultAsync(x => x.SearchCode!.ToLower().Equals(searchCode.ToLower()));
            return item is null;
        }

        private async Task<bool> CheckAirportCity(Flight flight)
        {
            var originAirport = await appDbContext.Airports.FirstOrDefaultAsync(x => x.Id!.Equals(flight.OriginAirportId));
            var destinyAirport = await appDbContext.Airports.FirstOrDefaultAsync(x => x.Id!.Equals(flight.DestinyAirportId));
            var isCityEqual = (originAirport!.CityId == destinyAirport!.CityId);
            return isCityEqual;
        }
        private static bool CheckFlightTime(Flight flight)
        {
            return flight.FlightTime <= DateTime.UtcNow;
        }
    }
}
