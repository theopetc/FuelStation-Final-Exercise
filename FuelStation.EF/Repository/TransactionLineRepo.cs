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
    public class TransactionLineRepo
    {
        private readonly FuelStationContext context;
        public TransactionLineRepo(FuelStationContext dbCOntext)
        {
            context = dbCOntext;
        }        
        
        public async Task CreateAsync(TransactionLine entity)
        {
            await context.TransactionLines.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var foundTransLine = await context.TransactionLines.SingleOrDefaultAsync(transLine => transLine.ID == id);
            if (foundTransLine is null)
                return;

            context.TransactionLines.Remove(foundTransLine);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransactionLine>> GetAllAsync()
        {
            return await context.TransactionLines.ToListAsync();
        }

        public async Task<TransactionLine?> GetByIdAsync(int id)
        {
            return await context.TransactionLines.SingleOrDefaultAsync(transline => transline.ID == id);
        }

        public async Task UpdateAsync(int id, TransactionLine entity)
        {
            var foundTransLine = await context.TransactionLines.SingleOrDefaultAsync(transLine => transLine.ID == id);
            if (foundTransLine is null)
                return;

            foundTransLine.ItemID = entity.ItemID;
            foundTransLine.TransactionID = entity.TransactionID;
            foundTransLine.Quantity = entity.Quantity;
            

            await context.SaveChangesAsync();
        }
    }
}
