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
    }
}
