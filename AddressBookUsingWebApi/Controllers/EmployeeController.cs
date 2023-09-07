using AddressBookUsingWebApi.Models;
using AddressBookUsingWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookUsingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            Employee record = await EmployeeRepository.AddEmployeeAsync(employee);
            return Ok(record);
        }

        [HttpGet,Route("DeleteById/{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            await EmployeeRepository.DeleteEmployeeAsync(id);
            return Ok("Deletion success");
        }

        [HttpPost,Route("Update")]
        public async Task<ActionResult> EditEmployee(Employee employee)
        {
            await EmployeeRepository.EditEmployeeAsync(employee);
            return Ok("goi it");
        }

        [HttpGet,Route("GetById/{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            Employee record = await EmployeeRepository.GetEmployeeByIdAsync(id);
            return Ok(record);
        }

        [HttpGet,Route("GetAll")]
        public async Task<ActionResult> GetAllEmployees()
        {
            List<Employee> employees = await EmployeeRepository.GetAllAsync();
            return Ok(employees);
        }
    }
}