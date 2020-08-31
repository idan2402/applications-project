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
        }


        public DbSet<EZ_CD.Models.Artist> Artist { get; set; }


        public DbSet<EZ_CD.Models.Disk> Disk { get; set; }

        public DbSet<EZ_CD.Models.Sale> Sale { get; set; }

        public DbSet<EZ_CD.Models.Song> Song { get; set; }
        public DbSet<EZ_CD.Models.SaleItem> SaleItem { get; set; }
        public DbSet<EZ_CD.Models.CartItem> CartItem { get; set; }

    }
}
