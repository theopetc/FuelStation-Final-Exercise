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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(employee => employee.ID);
            builder.Property(employee => employee.ID).ValueGeneratedOnAdd();
            builder.Property(employee => employee.Name).HasMaxLength(30);
            builder.Property(employee => employee.Surname).HasMaxLength(30);
            builder.Property(employee => employee.HireDateStart);
            builder.Property(employee => employee.HireDateEnd);
            builder.Property(employee => employee.SallaryPerMonth).HasColumnType("decimal(10, 2)");

            builder.Property(employee => employee.EmployeeType)
                   .HasConversion(employeeType => employeeType.ToString(), employeeType => (EmployeeType)Enum.Parse(typeof(EmployeeType), employeeType));

            builder.HasMany(employee => employee.Transactions).WithOne(transaction => transaction.Employee)
                   .HasForeignKey(transaction => transaction.EmployeeID);
        }
    }
}
