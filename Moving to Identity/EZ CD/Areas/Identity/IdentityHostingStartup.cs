using System;
using EZ_CD.Areas.Identity.Data;
using EZ_CD.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EZ_CD.Areas.Identity.IdentityHostingStartup))]
namespace EZ_CD.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EZ_CD_DBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EZ_CD_DBContextConnection")));

                services.AddDefaultIdentity<User>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    })
                    .AddEntityFrameworkStores<EZ_CD_DBContext>();
            });
        }
    }
}