
using LibraryManagementSystem.Data;
using LibraryManagementSystem.SyncDataService.Http;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

          

            builder.Services.AddControllers();
        
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<AppDbContext>(opt => 
            opt.UseInMemoryDatabase("InMem"));

            builder.Services.AddScoped<IBookRepository,  BookRepository>();
            builder.Services.AddHttpClient<ICommandDataClient, HttpCBookDataClient>();
            Console.WriteLine($"--> CommandService Endpoints {builder.Configuration["CommandService"]}");

            var app = builder.Build();

            PrepDb.PrepPopulation(app);

            
                app.UseSwagger();
                app.UseSwaggerUI();
            

           app.UseHttpsRedirection();

            app.UseAuthorization();

            
     
            app.MapControllers();

            app.Run();
        }
    }
}
