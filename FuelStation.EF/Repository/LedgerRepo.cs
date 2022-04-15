using FuelStation.EF.Context;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repository
{
    public class LedgerRepo : IEntityRepo<Ledger>
    {
        private readonly FuelStationContext context;
        public LedgerRepo(FuelStationContext DbContext)
        {
            context = DbContext;
        }
        public async Task CreateAsync(Ledger entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ledger>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ledger?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Ledger entity)
        {
            throw new NotImplementedException();
        }
    }
}
