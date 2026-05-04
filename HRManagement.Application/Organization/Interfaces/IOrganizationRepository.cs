using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Organization.Interfaces
{
    public interface IOrganizationRepository
    {
        Task AddAsync(OrganizationUnit organization);
        Task UpdateAsync(OrganizationUnit organization);
        Task DeleteAsync(OrganizationUnit organization);

        Task<OrganizationUnit?> GetByIdAsync(Guid id);
        Task<IEnumerable<OrganizationUnit>> GetAllAsync();
    }
}
