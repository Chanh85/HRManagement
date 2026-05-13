using Dapper;
using HRManagement.Application.Common;
using HRManagement.Application.Position.Interfaces;
using HRManagement.Domain.Entities;
using HRManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HRManagement.Infrastructure.Repositories
{
    public class PositionRepository(AppDbContext dbContext, ISqlConnectionFactory connectionFactory) : IPositionRepository
    {
        public async Task AddAsync(Position position)
        {
            await dbContext.Positions.AddAsync(position);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Position position)
        {
            dbContext.Positions.Remove(position);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Position position)
        {
            dbContext.Positions.Update(position);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            using IDbConnection db = connectionFactory.CreateConnection();
            var sql = "SELECT * FROM Positions INNER JOIN Organizations ON Positions.OrganizationId = Organizations.Id " +
                "ORDER By Positions.CreatedAt DESC";
            var result = await db.QueryAsync<Position, OrganizationUnit, Position>(
                sql,
                (position, organization) =>
                {
                    position.Organization = organization;
                    return position;
                },
                splitOn: "Id"
                );
            return result;
        }

        public async Task<Position?> GetByIdAsync(Guid id)
        {
            using IDbConnection db = connectionFactory.CreateConnection();
            var sql = "SELECT * FROM Positions INNER JOIN Organizations ON Positions.OrganizationId = Organizations.Id " +
                "WHERE Positions.Id = @ID " +
                "ORDER By Positions.CreatedAt DESC";
            var result = await db.QueryAsync<Position, OrganizationUnit, Position>(
                sql,
                (position, organization) =>
                {
                    position.Organization = organization;
                    return position;
                },
                new { ID = id },
                splitOn: "Id"
                );
            return result.FirstOrDefault();
        }
    }
}
