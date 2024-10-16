using Dictionary.CLient.Blazor.WebApi.Infrastructure;

namespace Dictionary.CLient.Blazor.WebApi.Extnsions
{
    public static class Registrations
    {
        public static IServiceCollection AddService(this IServiceCollection services) 
        {
            services.AddScoped<IHttpService, HttpService>();
            return services;
        }
    }
}
