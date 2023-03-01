using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)     
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddDbContext<DataContext>(opt => opt
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));   
            return services;
        }
    }
}
