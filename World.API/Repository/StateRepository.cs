using Microsoft.EntityFrameworkCore;
using world.API.Data;
using world.API.Models;
using world.API.Repository.IRepository;

namespace world.API.Repository
{
    public class StateRepository : IStateRepository
    {
        private ApplicationDbContext _dbcontext;

        public StateRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }






        public async Task Create(State entity)
        {
           _dbcontext.states.Add(entity);
            await Save();
        }


        public async Task Update(State entity)
        {
            _dbcontext.states.Update(entity);
            await Save();
        }



        public async Task Delete(State entity)
        {
            _dbcontext.states.Remove(entity);
            await Save();  
        }

        
       

        public async Task<State> GetById(int id)
        {
           State  state =  await _dbcontext.states.FindAsync(id);
            return state;  
            
        }


        public async Task<List<State>> GetAll()
        {
           List<State> state = await _dbcontext.states.ToListAsync();
            return state;

        }




        public bool IsStateExist(string name)
        {
            var result = _dbcontext.states.AsQueryable().Where(x=>x.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }





        public async Task Save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        
    }
}
