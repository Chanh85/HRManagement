using Dapper;
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
    internal class EmployeeRepository: IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public EmployeeRepository(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }
        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryAsync<Employee>("SELECT * FROM Employees");
        }
    }
}
