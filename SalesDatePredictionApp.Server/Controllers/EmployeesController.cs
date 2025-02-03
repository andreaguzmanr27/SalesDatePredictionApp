using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models;

namespace SalesDatePredictionApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var employees = await _employeeService.GetEmployeesAsync();

            return Ok(employees);
        }
    }
}
