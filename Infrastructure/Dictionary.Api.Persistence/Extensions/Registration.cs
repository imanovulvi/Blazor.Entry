using Dictionary.Api.Application.Interface.Repository;
using Dictionary.Api.Domain.Entitys;
using Dictionary.Api.Persistence.Concret;
using Dictionary.Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DictionaryDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlDefaultCon")));

            services.AddScoped<IEmailConfigurationRepository, EmailConfigurationRepository>();
            services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();
            services.AddScoped<IEntryFavoriteRepository, EntryFavoriteRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEntryVoteRepository, EntryVoteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
