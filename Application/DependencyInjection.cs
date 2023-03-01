using Application.DTOS.Profiles;
using Application.Features.Customers.Commands.Validators;
using Application.Features.Customers.Querys;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCustomerQuery).Assembly));
            services.AddAutoMapper(typeof(CustomerProfile));

            services.AddValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>();
            services.AddFluentValidationAutoValidation();
            return services;
        }

    }
}
