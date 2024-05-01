using world.API.Models;

namespace world.API.Repository.IRepository
{
    public interface IStateRepository
    {
        Task Create(State entity);
        Task Update(State entity);
        Task Delete(State entity);
        Task Save();

        Task<List<State>> GetAll();
        Task<State> GetById(int id);

        bool IsStateExist(string name);
    }
}
