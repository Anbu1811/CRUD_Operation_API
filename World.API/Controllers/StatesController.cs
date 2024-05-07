using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using world.API.DTO.STATE;
using world.API.Models;
using world.API.Repository.IRepository;

namespace world.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public StatesController(IMapper mapper, IStateRepository stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public  async Task<ActionResult<CreateStateDTO>> Create([FromBody] CreateStateDTO statedto) 
        {
            var result = _stateRepository.IsStateExist(statedto.Name);

            if (result)
            {
                return Conflict("This name is already existed");
            }

            var map = _mapper.Map<State>(statedto);
            await  _stateRepository.Create(map);

            return CreatedAtAction("GetId", new { id = map.Id }, statedto);

        
        }

        [HttpPut ("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<UpdateStateDTO>> Update(int id, [FromBody] UpdateStateDTO statedto)
        {
            var update = _mapper.Map<State>(statedto);
           await _stateRepository.Update(update);

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<State>> Delete(int id)
        {
            var getid = await _stateRepository.GetById(id);

            if(getid == null)
            {
                return Conflict("Please give valuable id Number");
            }

            await _stateRepository.Delete(getid);

            return Ok();
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ShowStateDTO>> GetId(int id)
        {
            var getid = await _stateRepository.GetById(id);

            if (getid == null)
            {
                return Conflict("Please give valuable id Number");
            }

            var show = _mapper.Map<ShowStateDTO>(getid);

            return Ok(show);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ShowStateDTO>>> GetAll() 
        {
            var getAll = await _stateRepository.GetAll();

            if(getAll == null)
            {
                return NoContent();
            }

            var show = _mapper.Map<List<ShowStateDTO>>(getAll);

            return Ok(show);
        }
    }
}
