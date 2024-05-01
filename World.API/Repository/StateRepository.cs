using Microsoft.EntityFrameworkCore;
using world.API.Data;
using world.API.Models;
using world.API.Repository.IRepository;

namespace world.API.Repository
{
    public class StateRepository : IStateRepository
    {

        private ApplicationDbContext _dbContext { get; set; }

        public StateRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(State entity)
        {
            await _dbContext.states.AddAsync(entity);
            await Save();
        }

        public  async Task Update(State entity)
        {
             _dbContext.states.Update(entity);
            await Save();
        }

        public async Task Delete(State entity)
        {
            _dbContext.states.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<State>> GetAll()
        {
            List<State> result = await _dbContext.states.ToListAsync();
            return result;
        }

        public async Task<State> GetById(int id)
        {
            State state = await _dbContext.states.FindAsync(id);
            return state;
        }

        public bool IsStateExist(string name)
        {
            var result = _dbContext.states.AsQueryable().Where(x=>x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }
    }
}
