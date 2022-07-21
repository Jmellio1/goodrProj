using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace goodrProj.Data
{
    public class goodrProjContext : DbContext
    {
        public goodrProjContext(DbContextOptions<goodrProjContext> options)
            : base(options)
        {
        }

        public DbSet<goodrProj.Models.DisplayEmployee> Employee { get; set; }
    }
}
