using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Application.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
           Assembly asmb= Assembly.GetExecutingAssembly();
            services.AddAutoMapper(asmb);
            services.AddMediatR(x=>x.RegisterServicesFromAssembly(asmb));
            return services;
        }
    }
}
