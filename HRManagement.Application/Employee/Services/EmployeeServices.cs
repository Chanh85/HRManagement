using HRManagement.Application.Employee.DTOs.Input;
using HRManagement.Application.Employee.DTOs.Output;
using HRManagement.Application.Employee.Interfaces;
using HRManagement.Application.Organization.Interfaces;
using HRManagement.Application.Position.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Employee.Services
{
    public class EmployeeServices(
        IEmployeeRepository employeeRepository, 
        IOrganizationRepository organizationRepository, 
        IPositionRepository positionRepository) : IEmployeeService
    {
        public async Task CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = new Domain.Entities.Employee
            {
                Name = dto.Name,
                Code = dto.Code,
                Email = dto.Email,
                OtherEmail = dto.OtherEmail,
                AvatarFileId = dto.AvatarFileId,
                PhoneNumber = dto.PhoneNumber,
                JoinedDate = dto.JoinedDate,
                DateOfBirth = dto.DateOfBirth,
                IsFirstLogin = dto.IsFirstLogin,
                OrganizationUnitId = dto.OrganizationUnitId,
                PositionId = dto.PositionId,
            };
            await employeeRepository.AddAsync(employee);
        }

        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            var currentEmployee = await employeeRepository.GetByIdAsync(dto.Id) ??
                throw new Exception("Không tồn tại nhân sự");

            if (!string.IsNullOrWhiteSpace(dto.OrganizationUnitId.ToString()) && currentEmployee.OrganizationUnitId != dto.OrganizationUnitId)
            {
                var org = await organizationRepository.GetByIdAsync(dto.OrganizationUnitId);
                if (org == null) throw new Exception("Phòng ban mới không tồn tại!");
            }

            if (!string.IsNullOrWhiteSpace(dto.PositionId.ToString()) && currentEmployee.PositionId != dto.PositionId)
            {
                var pos = await positionRepository.GetByIdAsync(dto.PositionId);
                if (pos == null) throw new Exception("Chức vụ mới không tồn tại!");
            }

            currentEmployee.Name = dto.Name;
            currentEmployee.Code = dto.Code;
            currentEmployee.Email = dto.Email;
            currentEmployee.OtherEmail = dto.OtherEmail;
            currentEmployee.AvatarFileId = dto.AvatarFileId;
            currentEmployee.PhoneNumber = dto.PhoneNumber;
            currentEmployee.JoinedDate = dto.JoinedDate;
            currentEmployee.DateOfBirth = dto.DateOfBirth;
            currentEmployee.IsFirstLogin = dto.IsFirstLogin;
            currentEmployee.OrganizationUnitId = dto.OrganizationUnitId;
            currentEmployee.PositionId = dto.PositionId;
            currentEmployee.Organization = null;
            currentEmployee.Position = null;

            await employeeRepository.UpdateAsync(currentEmployee);
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid Id)
        {
            await employeeRepository.DeleteAsync(Id);
            return true;
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
                OrganizationName = e.Organization?.DisplayName?? "N/A",
                PositionId = e.PositionId,
                PositionName = e.Position?.Name?? "N/A",
                AvatarFileId = e.AvatarFileId,
                PhoneNumber = e.PhoneNumber,
                JoinedDate = e.JoinedDate,
                DateOfBirth = e.DateOfBirth
            });
        }

        public async Task<EmployeeOutputDto> GetEmployeeById(Guid Id)
        {
            var employee = await employeeRepository.GetByIdAsync(Id) ??
                throw new Exception("Nhân sự không tồn tại");
            return new EmployeeOutputDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Code = employee.Code,
                Email = employee.Email,
                OtherEmail = employee.OtherEmail,
                OrganizationUnitId = employee.OrganizationUnitId,
                OrganizationName = employee.Organization?.DisplayName?? "N/A",
                PositionId = employee.PositionId,
                PositionName = employee.Position?.Name?? "N/A",
                AvatarFileId = employee.AvatarFileId,
                PhoneNumber = employee.PhoneNumber,
                JoinedDate = employee.JoinedDate,
                DateOfBirth = employee.DateOfBirth
            };
        }


    }
}
