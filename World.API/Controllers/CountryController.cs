using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using world.API.Data;
using world.API.DTO.COUNTRY;
using World.API.Models;

namespace world.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CountryController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ShowCountryDTO>> GetAll() 
        {

            var countries = _dbContext.countries.ToList();

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
        public ActionResult<ShowCountryDTO> GetById(int id)
        {
            var countries = _dbContext.countries.Find(id);
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
        public ActionResult<CreateCountryDTO> Create([FromBody] CreateCountryDTO countryDto) 
        {
            var result = _dbContext.countries.AsQueryable().Where(x=>x.Name.ToLower().Trim() == 
            countryDto.Name.ToLower().Trim()).Any();

            if (result)
            {
                return Conflict("Country NAME is already exited or please insert value");
            }

            //Country country = new Country();
            //country.Name = countryDto.Name;
            //country.ShortName = countryDto.ShortName;
            //country.CountryCode = countryDto.CountryCode;

            var country = _mapper.Map<Country>(countryDto);

            _dbContext.countries.Add(country);
            _dbContext.SaveChanges();
            return CreatedAtAction("GetById", new {id = country.Id}, country);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<UpdateCountryDTO> Update(int id,[FromBody] UpdateCountryDTO countryDto) 
        {
            if(countryDto  == null  )
            {
                return BadRequest("ID NOT SAME");
            }

            /*_dbContext.countries.Find(id);

            if (countryfromDb == null)
            {
                return NotFound("NO DATA FOUND");
            } 

            countryfromDb.Name = country.Name;
            countryfromDb.ShortName = country.ShortName;
            countryfromDb.CountryCode = country.CountryCode;
            
             just for  purpose*/

            var country = _mapper.Map<Country>(countryDto);
            _dbContext.countries.Update(country);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Country> Delete(int id)
        {
            var country = _dbContext.countries.Find(id);

            if(country == null) 
            {
                return NotFound();
            }

            _dbContext.countries.Remove(country);
            _dbContext.SaveChanges();


            return Ok();
        }
    }
}
