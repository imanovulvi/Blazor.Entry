using Dictionary.Api.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Api.Persistence.EntitysConfiguration
{
    public class EntryCommentConfiguration : BaseConfiguration<EntryComment>
    {
        public override void Configure(EntityTypeBuilder<EntryComment> builder)
        {
            base.Configure(builder);

           builder
     .HasOne(x=>x.User)
     .WithMany(e => e.EntryComments)
     .HasForeignKey(ef => ef.UserId)
     .OnDelete(DeleteBehavior.Cascade); 

            builder
                .HasOne(ef => ef.Entry)
                .WithMany(u => u.EntryComments)
                .HasForeignKey(ef => ef.EntryId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
