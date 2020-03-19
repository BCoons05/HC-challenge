using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HealthCatalystApi.Models
{
    public class NameContext : DbContext
    {
        public NameContext(DbContextOptions<NameContext> options)
            : base(options)
        {
        }

        public DbSet<Name> Names { get; set; }
    }
}
