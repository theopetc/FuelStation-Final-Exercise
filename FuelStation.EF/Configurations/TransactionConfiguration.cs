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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(transaction => transaction.ID);
            builder.Property(transaction => transaction.ID).ValueGeneratedOnAdd();
            builder.Property(transaction => transaction.EmployeeID);
            builder.Property(transaction => transaction.CustomerID);
            builder.Property(transaction => transaction.Date);
            builder.Property(transaction => transaction.PaymentMethod)
                   .HasConversion(paymentMethod => paymentMethod.ToString(), paymentMethod => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentMethod));

            builder.Property(transaction => transaction.TotalValue).HasColumnType("decimal(10, 2)");


            builder.HasMany(transaction => transaction.TransactionLines).WithOne(transactionLine => transactionLine.Transaction)
                .HasForeignKey(transactionLine => transactionLine.TransactionID);

            builder.HasOne(transaction => transaction.Customer).WithMany(customer => customer.Transactions)
                .HasForeignKey(transaction => transaction.CustomerID);

            builder.HasOne(transaction => transaction.Employee).WithMany(employee => employee.Transactions)
                .HasForeignKey(transaction => transaction.EmployeeID);

        }
    }
}
