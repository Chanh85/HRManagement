using HRManagement.Application.Employee.DTOs.Input;
using HRManagement.Application.Employee.DTOs.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Employee.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeOutputDto>> GetAllEmployeesAsync();
        Task<EmployeeOutputDto> GetEmployeeById(Guid Id);
        Task CreateEmployeeAsync(CreateEmployeeDto dto);
        Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto dto);
        Task<bool> DeleteEmployeeAsync(Guid Id);
    }
}
