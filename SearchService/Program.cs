
using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Data;
using SearchService.Models;

namespace SearchService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseAuthorization();

            app.MapControllers();

            try
            {
                await DbInitializer.InitDb(app);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            app.Run();
        }
    }
}
