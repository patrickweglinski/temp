using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CS3750Project.Models;

namespace CS3750Project.Data
{
    public class CS3750ProjectContext : DbContext
    {
        public CS3750ProjectContext (DbContextOptions<CS3750ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<CS3750Project.Models.User> User { get; set; } = default!;

        public DbSet<CS3750Project.Models.Class>? Class { get; set; }
    }
}
