using Dictionary.Api.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Persistence.EntitysConfiguration
{
    public class EntryFavoriteConfiguration : BaseConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.User)
                .WithMany(x => x.EntryFavorites)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.Entry)
                .WithMany(x=>x.EntryFavorites)
                .HasForeignKey(x=>x.EntryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
