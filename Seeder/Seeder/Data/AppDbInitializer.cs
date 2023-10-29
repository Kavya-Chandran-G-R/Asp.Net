using Seeder.Data.Models;


namespace Seeder.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    object value = context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = " 1st book description",
                        IsRead = true,
                        DateReader = DateTime.Now.AddDays(-1),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "http...",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2st Book Title",
                        Description = " 2st book description",
                        IsRead = false,

                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "http...",
                        DateAdded = DateTime.Now
                    }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}