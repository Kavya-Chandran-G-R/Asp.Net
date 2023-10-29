using Microsoft.EntityFrameworkCore;

namespace Pagination.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Galaxy" },
                new Product { Id = 2, Name = "Samsung" },
                new Product { Id = 3, Name = "Android" },
                new Product { Id = 4, Name = "Phone" },
                new Product { Id = 5, Name = "Vivo" },
                new Product { Id = 6, Name = "One plus" },
                new Product { Id = 7, Name = "Realme" },
                new Product { Id = 8, Name = "Pixel" },
                new Product { Id = 9, Name = "Node" },
                new Product { Id = 10, Name = "Lap" }
                );
        }
      public  DbSet<Product>? Products { get; set; }
    }
}
