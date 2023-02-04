using Metflix.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Metflix.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services
                .Configure<ApiBehaviorOptions>(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            services.AddControllers(
                options => options.Filters.Add(typeof(ValidationFilter)));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
