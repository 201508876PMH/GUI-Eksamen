using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EksamenAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EksamenAPI.Data
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Opgave> Opgaver { get; set; }  
        public DbSet<Assignment> Assignments { get; set; }
    }
}
