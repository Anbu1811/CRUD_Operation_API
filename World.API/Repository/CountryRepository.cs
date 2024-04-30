using Microsoft.EntityFrameworkCore;
using world.API.Data;
using world.API.Repository.IRepository;
using World.API.Models;

namespace world.API.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task Create(Country entity)
        {
            await _dbContext.countries.AddAsync(entity);
            await Save();
        }

        public async Task Delete(Country entity)
        {
            _dbContext.countries.Remove(entity);
            await Save();
        }

        public async Task<List<Country>> GetAll()
        {
            List<Country> country = await _dbContext.countries.ToListAsync();
            return country;
        }

        public async Task<Country> GetById(int id)
        {
            Country country = await _dbContext.countries.FindAsync(id);
            return country;
        }

        

        public async Task Update(Country entity)
        {
            _dbContext.countries.Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public bool IsCountryExist(string name)
        {
            var result = _dbContext.countries.AsQueryable().Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }
    }
}
