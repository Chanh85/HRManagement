using HRManagement.Application.Employee.DTOs.Output;
using HRManagement.Application.Employee.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Employee.Services
{
    internal class EmployeeServices(
        IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public async Task CreateEmployeeAsync(Domain.Entities.Employee employee)
        {
            await employeeRepository.AddAsync(employee);
        }

        public async Task<IEnumerable<EmployeeOutputDto>> GetAllEmployeesAsync()
        {
            var employees = await employeeRepository.GetAllAsync();
            return employees.Select(e => new EmployeeOutputDto
            {
                Id = e.Id,
                Name = e.Name,
                Code = e.Code,
                Email = e.Email,
                OtherEmail = e.OtherEmail,
                OrganizationUnitId = e.OrganizationUnitId,
                PositionId = e.PositionId,
                AvatarFileId = e.AvatarFileId,
                PhoneNumber = e.PhoneNumber,
                JoinedDate = e.JoinedDate,
                DateOfBirth = e.DateOfBirth
            });
        }
    }
}
