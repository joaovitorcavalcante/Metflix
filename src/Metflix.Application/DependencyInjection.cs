using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Metflix.Application.Categories.Commands.CreateCategory;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Metflix.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}