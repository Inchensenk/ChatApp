﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatServer.EFCore.Entities;

namespace ChatServer.EFCore.EntitiesConfigurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(u => u.User).WithMany(u => u.Conversations);
        }
    }
}
