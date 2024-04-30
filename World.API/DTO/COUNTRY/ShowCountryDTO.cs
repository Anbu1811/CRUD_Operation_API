using System.ComponentModel.DataAnnotations;

namespace world.API.DTO.COUNTRY
{
    public class ShowCountryDTO
    {

       
        public int Id { get; set; }

        public string Name { get; set; }

        
        public string ShortName { get; set; }

       
        public string CountryCode { get; set; }

    }
}
