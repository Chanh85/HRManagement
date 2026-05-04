using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Employee.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Domain.Entities.Employee employee);
        Task<IEnumerable<Domain.Entities.Employee>> GetAllAsync();
    }
}
