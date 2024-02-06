using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CityRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<City>
    {
        public async Task<GeneralResponse> DeleteById(int id)
        {
            var city = await appDbContext.Cities.FindAsync(id);
            if(city is null) return NotFound();

            appDbContext.Cities.Remove(city);
            await Commit();
            return Success();
        }

        public async Task<List<City>> GetAll() => await appDbContext.Cities.ToListAsync();

        public async Task<City> GetById(int id) => await appDbContext.Cities.FindAsync(id);


        public async Task<GeneralResponse> Insert(City item)
        {
            if (!await CheckNameAndUF(item.Name!, item.UF!)) return new GeneralResponse(false, "Cidade já cadastrada");
            appDbContext.Cities.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(City item)
        {
            var city = await appDbContext.Cities.FindAsync(item.Id);
            if (city is null) return NotFound();

            city.Name = item.Name;
            city.UF = item.UF;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new(false, "Desculpe, Cidade não encontrada");
        private static GeneralResponse Success() => new(true, "Processo concluído");
        private async Task Commit() => await appDbContext.SaveChangesAsync();


        private async Task<bool> CheckNameAndUF(string name, string uf)
        {
            var item = await appDbContext.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()) && x.UF.ToLower().Equals(uf.ToLower()));
            return item is null;
        }
    }
}
