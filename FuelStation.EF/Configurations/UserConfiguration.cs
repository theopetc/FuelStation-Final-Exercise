using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.ID);
            builder.Property(user => user.ID).ValueGeneratedOnAdd();
            builder.Property(user => user.Username).HasMaxLength(10);
            builder.Property(user => user.Password).HasMaxLength(10);
        }
    }
}
