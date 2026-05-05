using Dapper;
using HRManagement.Application.Organization.Interfaces;
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
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly AppDbContext _context;
        private readonly string _connectionString;

        public OrganizationRepository(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }

        //--EFCore-- write queries
        public async Task AddAsync(OrganizationUnit organization)
        {
            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrganizationUnit organization)
        {
            _context.Organizations.Update(organization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrganizationUnit organization)
        {
            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
        }

        //--Dapper-- read queries
        public async Task<IEnumerable<OrganizationUnit>> GetAllAsync()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryAsync<OrganizationUnit>("SELECT * FROM Organizations ORDER BY CreatedAt DESC");
        }

        public async Task<OrganizationUnit?> GetByIdAsync(Guid id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return await db.QueryFirstOrDefaultAsync<OrganizationUnit>(
                "SELECT * FROM Organizations WHERE Id = @Id", new { Id = id });
        }
    }
}
