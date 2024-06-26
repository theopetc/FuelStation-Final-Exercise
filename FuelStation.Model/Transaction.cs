﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model
{
    public class Transaction : BaseEntity
    {
        public DateTime Date { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal? TotalValue { get; set; }
        public List<TransactionLine> TransactionLines { get; set; } = new List<TransactionLine>();
        //Relations
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Transaction()
        {

        }
    }
}
