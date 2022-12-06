using ChatServer.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.EFCore.EntitiesConfigurations
{
    public class AuthConfiguration : IEntityTypeConfiguration<Auth>
    {
        public void Configure(EntityTypeBuilder<Auth> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(u => u.User).WithOne(a => a.Auth).HasForeignKey<Auth>(a => a.UserId);
        }
    }
}
