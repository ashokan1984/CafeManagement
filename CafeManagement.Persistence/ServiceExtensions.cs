using CafeManagement.Application.Repository;
using CafeManagement.Persistence.Context;
using CafeManagement.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeManagement.Persistence;
public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("CafeManagementDBContext");
        services.AddDbContext<CafeManagementDBContext>(options => options.UseSqlServer(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICafeRepository, CafeRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
}
