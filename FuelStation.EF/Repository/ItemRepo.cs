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
    public class ItemRepo : IEntityRepo<Item>
    {
        private readonly FuelStationContext context = new FuelStationContext();
        public ItemRepo(FuelStationContext DbContext)
        {
            context = DbContext;
        }

        public async Task CreateAsync(Item entity)
        {
            if (entity.ID != 0)
                throw new ArgumentException("Given entity should not have Id set", nameof(entity));

            context.Items.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var itemToRemove = context.Items.SingleOrDefault(item => item.ID == id);
            if (itemToRemove is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            context.Items.Remove(itemToRemove);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await context.Items.Include(item => item.TransactionLine).ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            return await context.Items.Include(item => item.TransactionLine).SingleOrDefaultAsync(item => item.ID == id);
        }

        public async Task UpdateAsync(int id, Item entity)
        {
            var itemToUpdate = context.Items.SingleOrDefault(item => item.ID == id);
            if (itemToUpdate is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");

            itemToUpdate.Description = entity.Description;
            itemToUpdate.Cost = entity.Cost;
            itemToUpdate.Price = entity.Price;
            itemToUpdate.ItemType = entity.ItemType;

            await context.SaveChangesAsync();
        }
    }
}
