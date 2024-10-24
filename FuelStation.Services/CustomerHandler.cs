using FuelStation.Blazor.Shared;
using FuelStation.EF.Repository;
using FuelStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Services
{
    public class CustomerHandler
    {
        private readonly IEntityRepo<Customer> _customerRepo;
        public CustomerHandler(IEntityRepo<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<IEnumerable<CustomerListViewModel>> GetAllCustomers()
        {
            var result = await _customerRepo.GetAllAsync();
            return result.Select(x => new CustomerListViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                CardNumber = x.CardNumber
            });
        }
    }
}
