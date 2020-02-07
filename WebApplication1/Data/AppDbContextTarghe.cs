using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

    public class AppDbContextTarghe : DbContext
    {
        public AppDbContextTarghe (DbContextOptions<AppDbContextTarghe> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.BC_Targhe> BC_Targhe { get; set; }
    }
