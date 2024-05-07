﻿using System.ComponentModel.DataAnnotations;
using World.API.Models;

namespace world.API.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Population { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }

    }
}
