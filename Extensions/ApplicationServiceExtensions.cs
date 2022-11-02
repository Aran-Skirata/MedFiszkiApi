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
            options.UseSqlite(config.GetConnectionString("Database"));
        });

        return services;
    }
}