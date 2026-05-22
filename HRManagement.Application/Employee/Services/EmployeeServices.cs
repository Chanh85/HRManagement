using HRManagement.Application.Employee.DTOs.Input;
using HRManagement.Application.Employee.DTOs.Output;
using HRManagement.Application.Employee.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Employee.Services
{
    public class EmployeeServices(
        IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public async Task CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = new Domain.Entities.Employee
            {
                Name = dto.Name,
                Code = dto.Code,
                Email = dto.Email,
                OtherEmail = dto.OtherEmail,
                AvatarFileId = null,
                PhoneNumber = dto.PhoneNumber,
                JoinedDate = dto.JoinedDate,
                DateOfBirth = dto.DateOfBirth,
                IsFirstLogin = dto.IsFirstLogin
            };
            await employeeRepository.AddAsync(employee);
        }

        public async Task<bool> UpdateEmployeeAsync(UpdateEmployeeDto dto)
        {
            var currentEmployee = await employeeRepository.GetByIdAsync(dto.Id) ??
                throw new Exception("Không tồn tại nhân sự");

          

            currentEmployee.Name = dto.Name;
            currentEmployee.Code = dto.Code;
            currentEmployee.Email = dto.Email;
            currentEmployee.OtherEmail = dto.OtherEmail;
            currentEmployee.AvatarFileId = dto.AvatarFileId;
            currentEmployee.PhoneNumber = dto.PhoneNumber;
            currentEmployee.JoinedDate = dto.JoinedDate;
            currentEmployee.DateOfBirth = dto.DateOfBirth;
            currentEmployee.IsFirstLogin = dto.IsFirstLogin;

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
                AvatarFileId = e.AvatarFileId,
                PhoneNumber = e.PhoneNumber,
                JoinedDate = e.JoinedDate,
                DateOfBirth = e.DateOfBirth
            });
        }


        /// <summary>
        /// Retrieves an employee by their unique identifier and returns the employee information as a DTO.
        /// </summary>
        /// <param name="Id">The unique identifier of the employee.</param>
        /// <returns>An EmployeeOutputDto containing the employee's information including name, code, email, organization,
        /// position, and other details.</returns>
        /// <exception cref="Exception">Thrown when the employee with the specified ID does not exist.</exception>
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
                AvatarFileId = employee.AvatarFileId,
                PhoneNumber = employee.PhoneNumber,
                JoinedDate = employee.JoinedDate,
                DateOfBirth = employee.DateOfBirth
            };
        }


    }
}
