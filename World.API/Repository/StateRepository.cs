using Microsoft.EntityFrameworkCore;
using world.API.Data;
using world.API.Models;
using world.API.Repository.IRepository;

namespace world.API.Repository
{
    public class StateRepository : GenericRepository<State> , IStateRepository
    {
        private ApplicationDbContext _dbcontext;

        public StateRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }








        public async Task Update(State entity)
        {
            _dbcontext.states.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }



        

        
    }
}
