using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using world.API.Data;
using world.API.DTO.COUNTRY;
using world.API.Repository.IRepository;
using World.API.Models;

namespace world.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ShowCountryDTO>>> GetAll() 
        {

            var countries = await _countryRepository.GetAll();

            var countrydto = _mapper.Map<List<ShowCountryDTO>>(countries);

            if (countries == null)
            {
                return NoContent();
            }

            return Ok(countrydto);
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<ShowCountryDTO>> GetById(int id)
        {
            var countries = await _countryRepository.GetById(id);
            var countryDto = _mapper.Map<ShowCountryDTO>(countries);

            if(countryDto == null) 
            {
                return NoContent();
            }

            return Ok(countryDto);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public  async Task<ActionResult<CreateCountryDTO>> Create([FromBody] CreateCountryDTO countryDto) 
        {
            var result = _countryRepository.IsCountryExist(countryDto.Name);

            if (result)
            {
                return Conflict("Country NAME is already exited or please insert value");
            }


            var country = _mapper.Map<Country>(countryDto);

            await _countryRepository.Create(country);
            await _countryRepository.Save();
            return CreatedAtAction("GetById", new {id = country.Id}, country);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<UpdateCountryDTO>> Update(int id,[FromBody] UpdateCountryDTO countryDto) 
        {
            if(countryDto  == null  )
            {
                return BadRequest("ID NOT SAME");
            }


            var country = _mapper.Map<Country>(countryDto);
           await _countryRepository.Update(country);
            await _countryRepository.Save();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Country>> Delete(int id)
        {
            var country = await _countryRepository.GetById(id);

            if(country == null) 
            {
                return NotFound();
            }

            await _countryRepository.Delete(country);
            await _countryRepository.Save();

                    
            return Ok();
        }
    }
}
