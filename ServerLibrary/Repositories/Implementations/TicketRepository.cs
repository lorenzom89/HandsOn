using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class TicketRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Ticket>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var ticket = await appDbContext.Tickets.FindAsync(id);
            if (ticket is null) return NotFound();

            appDbContext.Tickets.Remove(ticket);
            await Commit();
            return Success();
        }

        public async Task<List<Ticket>> GetAll() => await appDbContext.Tickets.AsNoTracking().Include(t=>t.Passenger).Include(t=>t.FlightClass).Include(t=>t.Flight).ToListAsync();

        public async Task<Ticket> GetById(int id) => await appDbContext.Tickets.FindAsync(id);


        public async Task<GeneralResponse> Insert(Ticket item)
        {
            if (!await CheckSearchCode(item.SearchCode!)) return new GeneralResponse(false, "Passagem já cadastrada");
            if (!await CheckSeat(item.SearchCode!)) return new GeneralResponse(false, "Assento já ocupado");

            appDbContext.Tickets.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Ticket item)
        {
            var ticket = await appDbContext.Tickets.FindAsync(item.Id);
            if (ticket is null) return NotFound();

            ticket.SearchCode = item.SearchCode;
            ticket.Seat = item.Seat;
            ticket.PassengerId = item.PassengerId;
            ticket.FlightId = item.FlightId;
            ticket.FlightClassId = item.FlightClassId;
            ticket.Baggage = item.Baggage;
            ticket.TotalPrice = item.TotalPrice;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Desculpe, Passagem não encontrada");
        private static GeneralResponse Success() => new(true, "Processo concluído");
        private async Task Commit() => await appDbContext.SaveChangesAsync();


        private async Task<bool> CheckSearchCode(string searchCode)
        {
            var item = await appDbContext.Tickets.FirstOrDefaultAsync(x => x.SearchCode!.ToLower().Equals(searchCode.ToLower()));
            return item is null;
        }
        private async Task<bool> CheckSeat(string seat)
        {
            var item = await appDbContext.Tickets.FirstOrDefaultAsync(x => x.Seat!.ToLower().Equals(seat.ToLower()));
            return item is null;
        }
    }
}
