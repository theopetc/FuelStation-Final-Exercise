using FuelStation.Blazor.Shared;
using FuelStation.EF.Repository;
using FuelStation.Model;
using FuelStation.Services;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerHandler _customerHandler;
        public CustomerController(CustomerHandler customerHandler)
        {
            _customerHandler = customerHandler;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerListViewModel>> Get()
        {
            return await _customerHandler.GetAllCustomers();
        }

        /*

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
        }*/
    }
}
