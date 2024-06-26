﻿using Microsoft.EntityFrameworkCore;
using World.API.Models;

namespace world.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Country> countries { get; set; }
    }
}
