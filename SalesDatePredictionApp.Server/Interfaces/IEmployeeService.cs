using SalesDatePredictionApp.Server.Models.DTOs;

namespace SalesDatePredictionApp.Server.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployeesAsync();
    }
}
