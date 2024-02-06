using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class PassengerRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Passenger>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var passenger = await appDbContext.Passengers.FindAsync(id);
            if (passenger is null) return NotFound();

            appDbContext.Passengers.Remove(passenger);
            await Commit();
            return Success();
        }

        public async Task<List<Passenger>> GetAll() => await appDbContext.Passengers.ToListAsync();

        public async Task<Passenger> GetById(int id) => await appDbContext.Passengers.FindAsync(id);


        public async Task<GeneralResponse> Insert(Passenger item)
        {
            if (!await CheckCPF(item.CPF!)) return new GeneralResponse(false, "Passageiro já cadastrado");
            appDbContext.Passengers.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Passenger item)
        {
            var passenger = await appDbContext.Passengers.FindAsync(item.Id);
            if (passenger is null) return NotFound();

            passenger.Name = item.Name;
            passenger.CPF = item.CPF;
            passenger.DateOfBirth = item.DateOfBirth;
            passenger.Email = item.Email;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Desculpe, Passageiro não encontrado");
        private static GeneralResponse Success() => new(true, "Processo concluído");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private async Task<bool> CheckCPF(string CPF)
        {
            var item = await appDbContext.Passengers.FirstOrDefaultAsync(x => x.CPF!.ToLower().Equals(CPF.ToLower()));
            return item is null;
        }
    }
}