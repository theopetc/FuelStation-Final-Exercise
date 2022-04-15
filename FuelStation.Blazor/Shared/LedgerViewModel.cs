using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared
{
    public class LedgerViewModel
    {
        public int ID { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }
    }

    public class LedgerListViewModel
    {
        public List<LedgerViewModel> MonthlyLedgers { get; set; } = new List<LedgerViewModel>();
    }
}
