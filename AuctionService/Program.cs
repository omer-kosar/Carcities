
using AuctionService.Data;
using Microsoft.EntityFrameworkCore;

namespace AuctionService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AuctionDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            app.UseAuthorization();

            app.MapControllers();

            try
            {
                DbInitializer.Initialize(app);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            app.Run();
        }
    }
}
