using System.ComponentModel.DataAnnotations;

namespace world.API.DTO.STATE
{
    public class CreateStateDTO
    {

        
        public string Name { get; set; }
        public string Population { get; set; }
        public string CountryId { get; set; }
    }
}
