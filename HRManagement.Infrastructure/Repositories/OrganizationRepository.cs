using Dapper;
using HRManagement.Application.Common;
using HRManagement.Application.Organization.Interfaces;
using HRManagement.Domain.Entities;
using HRManagement.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System.Data;


namespace HRManagement.Infrastructure.Repositories
{
    public class OrganizationRepository(AppDbContext dbContext, ISqlConnectionFactory connectionFactory) : IOrganizationRepository
    {

        //--EFCore-- write queries
        public async Task AddAsync(OrganizationUnit organization)
        {
            await dbContext.Organizations.AddAsync(organization);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrganizationUnit organization)
        {
            dbContext.Organizations.Update(organization);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrganizationUnit organization)
        {
            dbContext.Organizations.Remove(organization);
            await dbContext.SaveChangesAsync();
        }

        //--Dapper-- read queries
        public async Task<IEnumerable<OrganizationUnit>> GetAllAsync()
        {
            using IDbConnection db = connectionFactory.CreateConnection();
            return await db.QueryAsync<OrganizationUnit>("SELECT * FROM Organizations ORDER BY CreatedAt DESC");
        }

        public async Task<OrganizationUnit?> GetByIdAsync(Guid id)
        {
            using IDbConnection db = connectionFactory.CreateConnection();
            return await db.QueryFirstOrDefaultAsync<OrganizationUnit>(
                "SELECT * FROM Organizations WHERE Id = @Id", new { Id = id });
        }
    }
}
