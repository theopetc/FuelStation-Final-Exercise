using FuelStation.Blazor.Shared;
using FuelStation.EF.Repository;
using FuelStation.Model;
using Microsoft.AspNetCore.Mvc;

namespace FuelStation.Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEntityRepo<Employee> _employeeRepo;
        public EmployeeController(IEntityRepo<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeListViewModel>> Get()
        {
            var result = await _employeeRepo.GetAllAsync();
            return result.Select(x => new EmployeeListViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                HireDateStart = x.HireDateStart,
                HireDateEnd = x.HireDateEnd,
                SallaryPerMonth = x.SallaryPerMonth,
                EmployeeType = x.EmployeeType
            });
        }

        [HttpGet("{id}")]
        public async Task<EmployeeListViewModel> Get(int id)
        {
            var result = await _employeeRepo.GetByIdAsync(id);
            return new EmployeeListViewModel
            {
                ID = result.ID,
                Name = result.Name,
                Surname = result.Surname,
                HireDateStart = result.HireDateStart,
                HireDateEnd = result.HireDateEnd,
                SallaryPerMonth = result.SallaryPerMonth,
                EmployeeType = result.EmployeeType
            };
        }

        [HttpPost]
        public async Task Post(EmployeeListViewModel employee)
        {
            var newEmployee = new Employee();
            newEmployee.Name = employee.Name;
            newEmployee.Surname = employee.Surname;
            newEmployee.HireDateStart = employee.HireDateStart;
            newEmployee.HireDateEnd = employee.HireDateEnd;
            newEmployee.SallaryPerMonth = employee.SallaryPerMonth;
            newEmployee.EmployeeType = employee.EmployeeType;

            await _employeeRepo.CreateAsync(newEmployee);

        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeRepo.DeleteAsync(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EmployeeListViewModel employee)
        {
            var employeeToUpdate = await _employeeRepo.GetByIdAsync(employee.ID);
            if (employeeToUpdate == null) return NotFound();

            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Surname = employee.Surname;    
            employeeToUpdate.HireDateStart = employee.HireDateStart;
            employeeToUpdate.HireDateEnd = employee.HireDateEnd;
            employeeToUpdate.SallaryPerMonth = employee.SallaryPerMonth;
            employeeToUpdate.EmployeeType = employee.EmployeeType;

            await _employeeRepo.UpdateAsync(employee.ID, employeeToUpdate);

            return Ok();
        }
    }
}
