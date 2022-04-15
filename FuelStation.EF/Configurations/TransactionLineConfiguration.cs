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
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
    {
        public void Configure(EntityTypeBuilder<TransactionLine> builder)
        {
            builder.ToTable("TransactionLines");
            builder.HasKey(transactionLine => transactionLine.ID);
            builder.Property(transactionLine => transactionLine.ID).ValueGeneratedOnAdd();
            builder.Property(transactionLine => transactionLine.TransactionID);
            builder.Property(transactionLine => transactionLine.ItemID);
            builder.Property(transactionLine => transactionLine.Quantity);
            builder.Property(transactionLine => transactionLine.ItemPrice).HasColumnType("decimal(10, 2)");
            builder.Property(transactionLine => transactionLine.NetValue).HasColumnType("decimal(10, 2)");
            builder.Property(transactionLine => transactionLine.DiscountPercent).HasColumnType("decimal(3, 2)");
            builder.Property(transactionLine => transactionLine.DiscountValue).HasColumnType("decimal(10, 2)");
            builder.Property(transactionLine => transactionLine.TotalValue).HasColumnType("decimal(10, 2)");

            builder.HasOne(transactionLine => transactionLine.Transaction).WithMany(transaction => transaction.TransactionLines)
                .HasForeignKey(transactionLine => transactionLine.TransactionID);

            builder.HasOne(transactionLine => transactionLine.Item).WithOne(item => item.TransactionLine)
                   .HasForeignKey<TransactionLine>(transactionLine => transactionLine.ItemID);


        }
    }
}
