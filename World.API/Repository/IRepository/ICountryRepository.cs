using World.API.Models;

namespace world.API.Repository.IRepository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);

        Task Create(Country country);
        Task Update(Country country);
        Task Delete(Country country);
        Task Save();

        bool IsCountryExist(string name);
    }
}
