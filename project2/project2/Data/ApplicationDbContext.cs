using Microsoft.EntityFrameworkCore;
using project2.Models;

namespace project2.Data
{
    
    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            public DbSet<Register> Registers { get; set; }

        }
    
}

