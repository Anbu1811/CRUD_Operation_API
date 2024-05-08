using System.Linq.Expressions;
using world.API.Models;

namespace world.API.Repository.IRepository
{
    public interface IGenericRepository <T> where T : class
    {
        Task Create(T entity);
       
        Task Delete(T entity);
        Task Save();

        Task<List<T>> GetAll();
        Task<T> Get(int id);

        bool IsRecordExist(Expression<Func<T, bool>> condition);
    }
}
