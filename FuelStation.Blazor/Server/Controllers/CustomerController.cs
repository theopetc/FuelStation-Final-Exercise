using FuelStation.Blazor.Shared;
using FuelStation.EF.Repository;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IEntityRepo<Customer> _customerRepo;
        public CustomerController(IEntityRepo<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerListViewModel>> Get()
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

        [HttpGet("{id}")]
        public async Task<CustomerListViewModel> Get(int id)
        {
            var result = await _customerRepo.GetByIdAsync(id);
            return new CustomerListViewModel
            {
                ID = result.ID,
                Name = result.Name,
                Surname = result.Surname,
                CardNumber = result.CardNumber
            };
        }

        [HttpPost]
        public async Task Post(CustomerListViewModel customer)
        {
            var newCustomer = new Customer();
            newCustomer.Name = customer.Name;
            newCustomer.Surname = customer.Surname;
            newCustomer.CardNumber = customer.CardNumber;

            await _customerRepo.CreateAsync(newCustomer);

        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _customerRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CustomerListViewModel customer)
        {
            var customerToUpdate = await _customerRepo.GetByIdAsync(customer.ID);
            if (customerToUpdate == null) return NotFound();

            customerToUpdate.Name = customer.Name;
            customerToUpdate.Surname = customer.Surname;
            customerToUpdate.CardNumber = customer.CardNumber;

            await _customerRepo.UpdateAsync(customer.ID, customerToUpdate);

            return Ok();
        }
    }
}
