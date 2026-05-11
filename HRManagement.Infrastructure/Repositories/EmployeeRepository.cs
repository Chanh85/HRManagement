using Dapper;
using HRManagement.Application.Common;
using HRManagement.Application.Employee.Interfaces;
using HRManagement.Domain.Entities;
using HRManagement.Infrastructure.Data;
using Microsoft.Data.SqlClient;
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

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using IDbConnection db = connectionFactory.CreateConnection();
            return await db.QueryAsync<Employee>("SELECT * FROM Employees");
        }
    }
}
