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
    public class EntryVoteConfiguration:BaseConfiguration<EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            base.Configure(builder);
            builder.HasOne(x=>x.User)
                .WithMany(x=>x.EntryVotes)
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Entry)
          .WithMany(x => x.EntryVotes)
          .HasForeignKey(x => x.EntryId)
          .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
