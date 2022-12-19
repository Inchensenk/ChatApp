using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatClient.MVVM.Model.Entities;

namespace ChatClient.MVVM.Model.EFCore.EntitiesConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(c => c.Conversation).WithMany(m => m.Messages);
        }
    }
}
