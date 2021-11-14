using apiCatedratico.Models;
using apiCurso.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCatedratico.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Catedratico> catedratico { get; set; }
        public DbSet<Curso> curso { get; set; }
    }
}
