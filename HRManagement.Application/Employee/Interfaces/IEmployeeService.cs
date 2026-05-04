using HRManagement.Application.Employee.DTOs.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Employee.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeOutputDto>> GetAllEmployeesAsync();
        Task CreateEmployeeAsync(Domain.Entities.Employee employee);
    }
}
