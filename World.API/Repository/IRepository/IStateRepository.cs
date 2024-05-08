using world.API.Models;

namespace world.API.Repository.IRepository
{
    public interface IStateRepository : IGenericRepository<State>
    {
       
        Task Update(State entity);
        
    }
}
