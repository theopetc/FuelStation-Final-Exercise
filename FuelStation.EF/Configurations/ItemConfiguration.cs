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
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(item => item.ID);
            builder.Property(item => item.ID).ValueGeneratedOnAdd();
            builder.Property(item => item.ItemType).HasConversion(itemType => itemType.ToString(), itemType => (ItemType)Enum.Parse(typeof(ItemType), itemType)); ;
            builder.Property(item => item.Cost).HasColumnType("decimal(10, 2)");
            builder.Property(item => item.Price).HasColumnType("decimal(10, 2)");

            builder.HasOne(item => item.TransactionLine)
                .WithOne(transactionLine => transactionLine.Item)
                .HasForeignKey<TransactionLine>(transactionLine => transactionLine.ItemID);            
        }
    }
}
