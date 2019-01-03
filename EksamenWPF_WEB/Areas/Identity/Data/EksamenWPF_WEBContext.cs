using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EksamenWPF_WEB.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EksamenWPF_WEB.Models;

namespace EksamenWPF_WEB.Models
{
    public class EksamenWPF_WEBContext : IdentityDbContext<EksamenWPF_WEBUser>
    {
        public EksamenWPF_WEBContext(DbContextOptions<EksamenWPF_WEBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<EksamenWPF_WEB.Models.Model> Model { get; set; }
    }
}
