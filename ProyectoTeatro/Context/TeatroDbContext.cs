using Microsoft.EntityFrameworkCore;
using ProyectoTeatro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTeatro.Context
{
    public class TeatroDbContext : DbContext
    {
        public TeatroDbContext(DbContextOptions<TeatroDbContext> options): base(options)
        {
        }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Sala> Salas { get; set; }                                                  
    }

}
