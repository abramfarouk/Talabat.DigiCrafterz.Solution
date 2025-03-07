
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Helper;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Custom Services


            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionDB")); }

            );

            builder.Services.AddAutoMapper(typeof(MappingProfiles));

            var app = builder.Build();



            //Update Database Dynamic
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var _context = services.GetRequiredService<ApplicationDbContext>();
            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await _context.Database.MigrateAsync();
                await ContextSeeding.SeedAsync(_context);
            }
            catch (Exception ex)
            {
                //Log For Display Exceptions
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an Error during Apply Migration");
            }






            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
