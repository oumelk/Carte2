using Carte2Layer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace carte2Layer.Infrastructure
{
    public class CarteDbContext : DbContext
    {
        public CarteDbContext(DbContextOptions<CarteDbContext> options) : base(options)
        {

        }

        public DbSet<Citoyen> Citoyens { get; set; }
    }
}

