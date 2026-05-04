using HRManagement.Application.Organization.DTOs.Input;
using HRManagement.Application.Organization.DTOs.Output;
using HRManagement.Application.Organization.Interfaces;
using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Organization.Service
{
    internal class OrganizationService(IOrganizationRepository _repository) : IOrganizationService
    {
        public async Task CreateAsync(CreateOrganizationDto dto)
        {
            var org = new OrganizationUnit
            {
                DisplayName = dto.DisplayName,
                Description = dto.Description
            };
            await _repository.AddAsync(org);
        }

        public async Task DeleteAsync(Guid id)
        {
            var org = await _repository.GetByIdAsync(id);
            if (org == null) throw new Exception("Không tìm thấy phòng ban!");

            await _repository.DeleteAsync(org);
        }

        public async Task<IEnumerable<OrganizationOutputDto>> GetAllAsync()
        {
            var orgs = await _repository.GetAllAsync();
            return orgs.Select(o => new OrganizationOutputDto { Id = o.Id, DisplayName = o.DisplayName, Description = o.Description });
        }

        public async Task<OrganizationOutputDto?> GetByIdAsync(Guid id)
        {
            var org = await _repository.GetByIdAsync(id);
            if (org == null) return null;
            return new OrganizationOutputDto { Id = org.Id, DisplayName = org.DisplayName, Description = org.Description };
        }

        public async Task UpdateAsync(UpdateOrganizationDto dto)
        {
            // 1. Phải lấy data cũ lên kiểm tra xem có tồn tại không
            var org = await _repository.GetByIdAsync(dto.Id);
            if (org == null) throw new Exception("Không tìm thấy phòng ban!");

            // 2. Cập nhật các trường được phép sửa
            org.DisplayName = dto.DisplayName;
            org.Description = dto.Description;

            await _repository.UpdateAsync(org);
        }
    }
}
