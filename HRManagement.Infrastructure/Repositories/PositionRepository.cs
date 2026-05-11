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
            return await db.QueryAsync<Position>("SELECT * FROM Positions ORDER BY CreatedAt DESC");
        }

        public async Task<Position?> GetByIdAsync(Guid id)
        {
            using IDbConnection db = connectionFactory.CreateConnection();
            return await db.QueryFirstOrDefaultAsync<Position?>("SELECT * FROM Positions WHERE Id = @ID", new {ID = id});
        }
    }
}
