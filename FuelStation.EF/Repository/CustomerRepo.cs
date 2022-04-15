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
    public class CustomerRepo : IEntityRepo<Customer>
    {
        private readonly FuelStationContext context = new FuelStationContext();
        public CustomerRepo(FuelStationContext dbContext)
        {
            context = dbContext;
        }        

        public async Task CreateAsync(Customer entity)
        {
            if (entity.ID != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            context.Customers.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var foundCustomer = await context.Customers.SingleOrDefaultAsync(customer => customer.ID == id);
            if (foundCustomer is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            context.Customers.Remove(foundCustomer);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await context.Customers.SingleOrDefaultAsync(customer => customer.ID == id);

        }

        public async Task UpdateAsync(int id, Customer entity)
        {
            var foundCustomer = await context.Customers.SingleOrDefaultAsync(customer => customer.ID == id);
            if (foundCustomer is null)
                return;

            foundCustomer.Name = entity.Name;
            foundCustomer.Surname = entity.Surname;
            foundCustomer.CardNumber = entity.CardNumber;

            await context.SaveChangesAsync();
        }
    }
}
