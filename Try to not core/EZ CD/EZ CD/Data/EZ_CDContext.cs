using EZ_CD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EZ_CD.Data
{
    public class EZ_CDContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EZ_CDContext() : base("name=EZ_CDContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleDetailes>().HasKey(sd => new { sd.diskId, sd.saleId });
            modelBuilder.Entity<SaleDetailes>().HasOptional(sd => sd.disk).WithMany(s => s.disksSalesDetailes).HasForeignKey(sd => sd.diskId);
            modelBuilder.Entity<SaleDetailes>().HasOptional(sd => sd.sale).WithMany(s => s.disksSalesDetailes).HasForeignKey(sd => sd.saleId);
        }
        public System.Data.Entity.DbSet<EZ_CD.Models.Admin> Admins { get; set; }
    }
}
