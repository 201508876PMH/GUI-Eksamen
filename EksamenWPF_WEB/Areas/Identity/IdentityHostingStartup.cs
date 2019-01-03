using System;
using EksamenWPF_WEB.Areas.Identity.Data;
using EksamenWPF_WEB.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EksamenWPF_WEB.Areas.Identity.IdentityHostingStartup))]
namespace EksamenWPF_WEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<EksamenWPF_WEBContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("EksamenWPF_WEBContextConnection")));

            //    services.AddDefaultIdentity<EksamenWPF_WEBUser>()
            //        .AddEntityFrameworkStores<EksamenWPF_WEBContext>();
            //});
        }
    }
}