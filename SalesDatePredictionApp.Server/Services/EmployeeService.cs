using Microsoft.EntityFrameworkCore;
using SalesDatePredictionApp.Server.Data;
using SalesDatePredictionApp.Server.Interfaces;
using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly StoreSampleContext _context;

        public EmployeeService(StoreSampleContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _context.Employees
                .Select(e => new EmployeeDto
                {
                    Empid = e.Empid,
                    FullName = e.Firstname + " " + e.Lastname
                })
            .ToListAsync();

            return employees;
        }
    }

}
