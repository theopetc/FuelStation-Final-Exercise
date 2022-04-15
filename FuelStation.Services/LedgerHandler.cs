using FuelStation.EF.Context;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Services
{
    public class LedgerHandler
    {
        private const int _RENT_COST = 5000;
        private readonly FuelStationContext _context;

        public LedgerHandler(FuelStationContext context)
        {
            _context = context;

        }

        public async Task<decimal> GetIncome(Ledger ledger)
        {
            int year = int.Parse(ledger.Year);
            int month = int.Parse(ledger.Month);
            return await _context.Transactions.Where(transaction => transaction.Date.Year == year && transaction.Date.Month == month)
                                              .SumAsync(transaction => transaction.TotalValue);
        }

        private async Task<decimal> GetProductExpences(Ledger ledger)
        {
            int year = int.Parse(ledger.Year);
            int month = int.Parse(ledger.Month);
            return await _context.Transactions.Where(transaction => transaction.Date.Year == year && transaction.Date.Month == month)
                                              .SumAsync(transaction => transaction.TotalValue);

        }

        private async Task<decimal> GetStuffExpences()
        {
            return await _context.Employees.SumAsync(employee => employee.SallaryPerMonth);
        }

        public async Task<decimal> GetMonthlyExpenses(Ledger ledger)
        {
            return await GetProductExpences(ledger) + await GetStuffExpences() + _RENT_COST;
        }

        public decimal GetTotal(Ledger ledger)
        {
            return ledger.Income - ledger.Expenses;
        }

        //public async Task<bool> MonthlyLedgerExists(Ledger ledger)
        //{
        //    return await _context.MonthlyLedgers.FirstOrDefaultAsync(monthlyL => monthlyL.Year == monthlyLedger.Year && monthlyL.Month == monthlyLedger.Month) is not null;
        //}
    }
}
