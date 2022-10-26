using MedFiszkiApi.Data;
using MedFiszkiApi.Helpers;
using MedFiszkiApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedFiszkiApi.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IAnatomyTranslationsRepository, AnatomyTranslationsRepository>();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        services.AddDbContext<MedFiszkiApi.Data.DataContext>(options =>
        {
<<<<<<< HEAD
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            string connStr;
            if (env == "Development")
            {
                // Use connection string from file.
                connStr = config.GetConnectionString("MedFiszkiDb");
            }
            else
            {
                var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                // Parse connection URL to connection string for Npgsql
                connUrl = connUrl.Replace("postgres://", string.Empty);
                var pgUserPass = connUrl.Split("@")[0];
                var pgHostPortDb = connUrl.Split("@")[1];
                var pgHostPort = pgHostPortDb.Split("/")[0];
                var pgDb = pgHostPortDb.Split("/")[1];
                var pgUser = pgUserPass.Split(":")[0];
                var pgPass = pgUserPass.Split(":")[1];
                var pgHost = pgHostPort.Split(":")[0];
                var pgPort = pgHostPort.Split(":")[1];

                connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};SSL Mode=Require;TrustServerCertificate=True";
            }
            options.UseNpgsql(connStr);
=======
            options.UseSqlite(config.GetConnectionString("MedFiszkiDb"));
>>>>>>> parent of 8e2699d (Switch from SQLite to PostgreSQL)
        });

        return services;
    }
}