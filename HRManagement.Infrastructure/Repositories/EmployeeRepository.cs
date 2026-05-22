using Dapper;
using HRManagement.Application.Common;
using HRManagement.Application.Employee.Interfaces;
using HRManagement.Domain.Entities;
using HRManagement.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HRManagement.Infrastructure.Repositories
{
    internal class EmployeeRepository(AppDbContext dbContext, ISqlConnectionFactory connectionFactory): IEmployeeRepository
    {
        public async Task AddAsync(Employee employee)
        {
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid Id)
        {
            var rowsAffected = await dbContext.Employees.Where(e => e.Id == Id).ExecuteDeleteAsync();
            if (rowsAffected == 0)
            {
                throw new Exception("Nhân sự không tồn tại");
            }
        }



        public async Task<Employee?> GetByIdAsync(Guid Id)
        {
            using IDbConnection db = connectionFactory.CreateConnection();
            var sql = @"select * 
                        from Employees left join Roles on Employees.RoleId = Roles.Id 
                        where Employees.Id = @Id 
                        order by JoinedDate desc";
            var employee = await db.QueryAsync<Employee, Role, Employee>(
                sql,
                (employee, role) =>
                {
                    employee.RoleId = role.Id;
                    return employee;
                },
                new {ID = Id},
                splitOn: "Id, Id"
                );
            return employee.FirstOrDefault();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using IDbConnection db = connectionFactory.CreateConnection();
            var sql = @"select * 
                        from Employees left join Roles on Employees.RoleId = Roles.Id 
                        order by JoinedDate desc";
            var employees = await db.QueryAsync<Employee, Role, Employee>(
                sql,
                (employee, role) =>
                {
                    employee.RoleId = role.Id;
                    return employee;
                },
                splitOn: "Id, Id"
                );
            return employees;
        }
    }
}
