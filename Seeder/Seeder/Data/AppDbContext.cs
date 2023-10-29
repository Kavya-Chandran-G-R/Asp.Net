using Microsoft.EntityFrameworkCore;
using Seeder.Data.Models;
using System.Collections.Generic;

namespace Seeder.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Book> UsBooks { get; set; }
        public object Books { get; internal set; }
    }
}
