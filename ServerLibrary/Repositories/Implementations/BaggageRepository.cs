using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class BaggageRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Baggage>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var baggage = await appDbContext.Baggages.FindAsync(id);
            if (baggage is null) return NotFound();

            appDbContext.Baggages.Remove(baggage);
            await Commit();
            return Success();
        }

        public async Task<List<Baggage>> GetAll() => await appDbContext.Baggages.ToListAsync();

        public async Task<Baggage> GetById(int id) => await appDbContext.Baggages.FindAsync(id);


        public async Task<GeneralResponse> Insert(Baggage item)
        {
            if (!await CheckSearchCode(item.SearchCode!)) return new GeneralResponse(false, "Bagagem já cadastrada");
            appDbContext.Baggages.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Baggage item)
        {
            var baggage = await appDbContext.Baggages.FindAsync(item.Id);
            if (baggage is null) return NotFound();

            baggage.SearchCode = item.SearchCode;
            baggage.TicketId = item.TicketId;

            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Desculpe, Bagagem não encontrada");
        private static GeneralResponse Success() => new(true, "Processo concluído");
        private async Task Commit() => await appDbContext.SaveChangesAsync();


        private async Task<bool> CheckSearchCode(string searchCode)
        {
            var item = await appDbContext.Baggages.FirstOrDefaultAsync(x => x.SearchCode!.ToLower().Equals(searchCode.ToLower()));
            return item is null;
        }
    }
}
