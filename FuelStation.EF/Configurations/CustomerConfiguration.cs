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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(customer => customer.ID);
            builder.Property(customer => customer.ID).ValueGeneratedOnAdd();

            builder.Property(customer => customer.Name).HasMaxLength(30);
            builder.Property(customer => customer.Surname).HasMaxLength(30);
            builder.Property(customer => customer.CardNumber);

            builder.HasMany(customer => customer.Transactions).WithOne(transaction => transaction.Customer)
                   .HasForeignKey(customer => customer.ID);
        }
    }
}
