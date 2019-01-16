using KendoDemo.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KendoDemo.API
{
    public class KendoContext : DbContext
    {
        public DbSet<Kendo> Kendos { get; set; }

        public KendoContext() : base()
        {
        }

        public KendoContext(DbContextOptions options) : base(options)
        {
        }
    }
}
