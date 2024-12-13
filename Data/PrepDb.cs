using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data
{
    public static class PrepDb
    {

       

        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Book.Any())
            {
                Console.WriteLine("We are seeding data!");

                context.Book.AddRange(
                    new Book() { Title = "Cant hurt me", Author = "David Goggins", Price = 30 },
                    new Book() { Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 19.99m },
                    new Book() { Title = "My biography", Author = "Hristo Stoichkov", Price = 35.99m }
                    );

                context.SaveChanges();
            } 
            else
            {
                Console.WriteLine("We already have data!");
            }


        }
    }
}
