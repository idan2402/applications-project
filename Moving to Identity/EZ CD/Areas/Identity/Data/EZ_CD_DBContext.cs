using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EZ_CD.Areas.Identity.Data;
using EZ_CD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EZ_CD.Data
{
    public class EZ_CD_DBContext : IdentityDbContext<User>
    {
        public EZ_CD_DBContext(DbContextOptions<EZ_CD_DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<SaleDetailes>().HasKey(sd => new { sd.DiskId, sd.SaleId });
            //builder.Entity<SaleDetailes>().HasOne(sd => sd.disk).WithMany(s => s.disksSalesDetailes).HasForeignKey(sd => sd.DiskId);
            //builder.Entity<SaleDetailes>().HasOne(sd => sd.sale).WithMany(s => s.disksSalesDetailes).HasForeignKey(sd => sd.SaleId);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        public DbSet<EZ_CD.Models.Artist> Artist { get; set; }


        public DbSet<EZ_CD.Models.Disk> Disk { get; set; }

        public DbSet<EZ_CD.Models.Sale> Sale { get; set; }

        public DbSet<EZ_CD.Models.Song> Song { get; set; }
        public DbSet<EZ_CD.Models.SaleItem> SaleItem { get; set; }
        public DbSet<EZ_CD.Models.CartItem> CartItem { get; set; }

    }
}
