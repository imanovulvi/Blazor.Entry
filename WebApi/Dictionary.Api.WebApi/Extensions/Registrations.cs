using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dictionary.Api.WebApi.Extensions
{
    public static class Registrations
    {
        public static IServiceCollection AddAuthSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication().AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,

                    ValidateIssuerSigningKey = true,//tokene uygun bir key deyer
                    ValidIssuer = configuration["TokenSecurty:issuer"],
                    ValidAudience = configuration["TokenSecurty:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenSecurty:securityKey"])),
                    LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) => expires != null ? expires > DateTime.UtcNow : false




                };
            }
            );
            return services;
        }

    }
}
