
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.MiddleWare;
using Talabat.Core.Helper;
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



            //Change Default Confirgure Error in Display Json 

            builder.Services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(Param => Param.Value.Errors.Count() > 0)
                    .SelectMany(P => P.Value.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToArray();

                    var validationErrors = new ApiValidationErrorsResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validationErrors);
                };
            });




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




            app.UseMiddleware<ExceptionMiddleWare>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Handle Not Found Pages
            app.UseStatusCodePagesWithReExecute("/errors/{0}"); //the better
            //app.UseStatusCodePagesWithRedirects("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
