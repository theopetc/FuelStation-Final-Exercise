using FuelStation.Blazor.Shared;
using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Services;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LedgerController : ControllerBase
    {
        private readonly IEntityRepo<Ledger> _ledgerRepo;
        private LedgerHandler _ledgerHandler;

        public LedgerController(IEntityRepo<Ledger> ledgerRepo, LedgerHandler ledgerHandler)
        {
            _ledgerRepo = ledgerRepo;
            _ledgerHandler = ledgerHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<LedgerViewModel>> Get()
        {
            var result = await _ledgerRepo.GetAllAsync();
            return result.Select(x => new LedgerViewModel
            {
                ID = x.ID,
                Year = x.Year,
                Month = x.Month,
                Income = x.Income,
                Expenses = x.Expenses,
                Total = x.Total
            });
        }

        [HttpDelete("{ID}")]
        public async Task Delete(int id)
        {
            await _ledgerRepo.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Post(LedgerViewModel ledgerView)
        {

            var newMonthly = new Ledger()
            {
                ID = ledgerView.ID,
                Year = ledgerView.Year,
                Month = ledgerView.Month
            };

            newMonthly.Income = await _ledgerHandler.GetIncome(newMonthly);
            newMonthly.Expenses = await _ledgerHandler.GetMonthlyExpenses(newMonthly);
            newMonthly.Total = _ledgerHandler.GetTotal(newMonthly);
            
            await _ledgerRepo.CreateAsync(newMonthly);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<LedgerViewModel> GetViewModel(int id)
        {
            LedgerViewModel model = new();
            if (id != 0)
            {
                var existing = await _ledgerRepo.GetByIdAsync(id);
                if (existing is null) return new LedgerViewModel();
                model.ID = existing.ID;
                model.Year = existing.Year;
                model.Month = existing.Month;
                model.Expenses = existing.Expenses;
                model.Total = existing.Total;
                model.Income = existing.Income;

            }
            return model;
        }
    }
}
