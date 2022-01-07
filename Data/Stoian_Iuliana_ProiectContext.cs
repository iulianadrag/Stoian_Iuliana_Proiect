using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stoian_Iuliana_Proiect.Models;

namespace Stoian_Iuliana_Proiect.Data
{
    public class Stoian_Iuliana_ProiectContext : DbContext
    {
        public Stoian_Iuliana_ProiectContext (DbContextOptions<Stoian_Iuliana_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Stoian_Iuliana_Proiect.Models.Movie> Movie { get; set; }

        public DbSet<Stoian_Iuliana_Proiect.Models.Studio> Studio { get; set; }

        public DbSet<Stoian_Iuliana_Proiect.Models.Category> Category { get; set; }
    }
}
