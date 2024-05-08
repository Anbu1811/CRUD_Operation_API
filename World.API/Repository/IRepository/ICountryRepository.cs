using World.API.Models;

namespace world.API.Repository.IRepository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
       
        Task Update(Country entity);
       
    }
}
