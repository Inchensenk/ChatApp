using ChatClient.MVVM.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.MVVM.Model.EFCore.EntitiesConfigurations
{
    class AuthConfiguration : IEntityTypeConfiguration<Auth>
    {
        public void Configure(EntityTypeBuilder<Auth> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(u => u.User).WithOne(a => a.Auth).HasForeignKey<Auth>(a => a.UserId);
        }
    }
}
