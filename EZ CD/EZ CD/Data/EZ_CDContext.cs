using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EZ_CD.Models;

namespace EZ_CD.Data
{
    public class EZ_CDContext : DbContext
    {
        public EZ_CDContext (DbContextOptions<EZ_CDContext> options)
            : base(options)
        {
        }

        public DbSet<EZ_CD.Models.Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleDetailes>().HasKey(sd => new { sd.diskId, sd.saleId });
            modelBuilder.Entity<SaleDetailes>().HasOne(sd => sd.disk).WithMany(s =>s.disksSalesDetailes).HasForeignKey(sd=>sd.diskId);
            modelBuilder.Entity<SaleDetailes>().HasOne(sd => sd.sale).WithMany(s => s.disksSalesDetailes).HasForeignKey(sd => sd.saleId);
        }

        public DbSet<EZ_CD.Models.SaleDetailes> SaleDetailes { get; set; }
    }
}
