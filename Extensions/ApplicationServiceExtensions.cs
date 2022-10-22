using MedFiszkiApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MedFiszkiApi.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<MedFiszkiApi.Data.DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("MedFiszkiDb"));
        });

        return services;
    }
}