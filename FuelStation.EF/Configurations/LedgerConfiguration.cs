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
    public class LedgerConfiguration : IEntityTypeConfiguration<Ledger>
    {
        public void Configure(EntityTypeBuilder<Ledger> builder)
        {
            builder.ToTable("MonthlyLedgers");
            builder.HasKey(monthlyLedger => monthlyLedger.ID);
            builder.Property(monthlyLedger => monthlyLedger.ID).ValueGeneratedOnAdd();
            builder.Property(monthlyLedger => monthlyLedger.Year).HasMaxLength(4);
            builder.Property(monthlyLedger => monthlyLedger.Month).HasMaxLength(2);
            builder.Property(monthlyLedger => monthlyLedger.Expenses).HasColumnType("decimal(10 ,2)");
            builder.Property(monthlyLedger => monthlyLedger.Income).HasColumnType("decimal(10 ,2)");
            builder.Property(monthlyLedger => monthlyLedger.Total).HasColumnType("decimal(10 ,2)");
        }
    }
}
