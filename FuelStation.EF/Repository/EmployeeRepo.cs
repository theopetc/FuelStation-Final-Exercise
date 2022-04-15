using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository
{
    public class EmployeeRepo : IEntityRepo<Employee>
    {
        private readonly FuelStationContext context;
        public EmployeeRepo(FuelStationContext dbCOntext)
        {
            context = dbCOntext;
        }

        public async Task CreateAsync(Employee entity)
        {
            if (entity.ID != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            context.Employees.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dbEmployee = await context.Employees.SingleOrDefaultAsync(employee => employee.ID == id);
            if (dbEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            context.Employees.Remove(dbEmployee);

            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task UpdateAsync(int id, Employee entity)
        {
            var dbEmployee = await context.Employees.SingleOrDefaultAsync(employee => employee.ID == id);
            if (dbEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");


            dbEmployee.Name = entity.Name;
            dbEmployee.Surname = entity.Surname;
            dbEmployee.SallaryPerMonth = entity.SallaryPerMonth;
            dbEmployee.EmployeeType = entity.EmployeeType;

            await context.SaveChangesAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await context.Employees.SingleOrDefaultAsync(employee => employee.ID == id);
        }
    }
}
