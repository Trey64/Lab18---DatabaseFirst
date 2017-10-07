using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab18Tom.Models;

namespace Lab18Tom.Models
{
    public class Lab18TomContext : DbContext
    {
        public Lab18TomContext (DbContextOptions<Lab18TomContext> options)
            : base(options)
        {
        }

        public DbSet<Lab18Tom.Models.Destinations> Destinations { get; set; }

        public DbSet<Lab18Tom.Models.Supplies> Supplies { get; set; }

        public DbSet<Lab18Tom.Models.DestinationSupplies> DestinationSupplies { get; set; }
    }
}
