using HRManagement.Application.Organization.DTOs.Input;
using HRManagement.Application.Organization.DTOs.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Organization.Interfaces
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationOutputDto>> GetAllAsync();
        Task<OrganizationOutputDto?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateOrganizationDto dto);
        Task UpdateAsync(UpdateOrganizationDto dto);
        Task DeleteAsync(Guid id);
    }
}
