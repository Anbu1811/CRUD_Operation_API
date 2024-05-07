using System.ComponentModel.DataAnnotations;
using World.API.Models;

namespace world.API.DTO.STATE
{
    public class UpdateStateDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Population { get; set; }
        public string CountryId { get; set; }
        
    }
}
