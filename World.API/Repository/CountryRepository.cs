using Microsoft.EntityFrameworkCore;
using world.API.Data;
using world.API.Repository.IRepository;
using World.API.Models;

namespace world.API.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



       

        

        public async Task Update(Country entity)
        {
            _dbContext.countries.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
