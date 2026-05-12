using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Position.Interfaces
{
    public interface IPositionRepository
    {
        Task AddAsync(Domain.Entities.Position position);
        Task UpdateAsync(Domain.Entities.Position position);
        Task DeleteAsync(Domain.Entities.Position position);
        Task<Domain.Entities.Position?> GetByIdAsync(Guid id);
        Task<IEnumerable<Domain.Entities.Position>> GetAllAsync();
    }
}
