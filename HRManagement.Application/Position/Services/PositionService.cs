using HRManagement.Application.Organization.Interfaces;
using HRManagement.Application.Position.DTOs.Input;
using HRManagement.Application.Position.DTOs.Output;
using HRManagement.Application.Position.Interfaces;
using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Position.Services
{
    public class PositionService(
        IPositionRepository positionRepository, 
        IOrganizationRepository organizationRepository) : IPositionService
    {
        public async Task CreateAsync(CreatePositionDto input)
        {
            // 1. KIỂM TRA LOGIC: Phòng ban có tồn tại không?
            var org = await organizationRepository.GetByIdAsync(input.OrganizationId);
            if (org == null)
                throw new Exception("Phòng ban không tồn tại! Vui lòng chọn phòng ban hợp lệ.");

            // 2. Tạo chức vụ mới
            var position = new Domain.Entities.Position
            {
                Name = input.Name,
                OrganizationId = input.OrganizationId
            };
            await positionRepository.AddAsync(position);
        }

        public async Task DeleteAsync(Guid id)
        {
            var currentPos = await positionRepository.GetByIdAsync(id) ?? 
                throw new Exception("Không thể xóa chức vụ không tồn tại!");

            await positionRepository.DeleteAsync(currentPos);
        }

        public async Task<IEnumerable<PositionOutputDto>> GetAsync()
        {
            var positions = await positionRepository.GetAllAsync();
            return positions.Select(p => new PositionOutputDto
            {
                Id = p.Id,
                Name = p.Name?? "N/A",
                OrganizationId = p.OrganizationId,
                OrganizationName = p.Organization?.DisplayName ?? "N/A"
            });
        }

        public async Task<PositionOutputDto?> GetByIdAsync(Guid id)
        {
            var p = await positionRepository.GetByIdAsync(id) ?? throw new Exception("Chức vụ không tồn tại");
            return new PositionOutputDto
            {
                Id = p.Id,
                Name = p.Name ?? "N/A",
                OrganizationId = p.OrganizationId,
                OrganizationName = p.Organization?.DisplayName ?? "N/A"
            };
        }

        public async Task<bool> UpdateAsync(UpdatePositionDto input)
        {
            var currentPos = await positionRepository.GetByIdAsync(input.Id) ??
                throw new Exception("Chức vụ không tồn tại!");


            // Nếu có thay đổi phòng ban, phải check lại xem phòng mới có tồn tại không
            if (!string.IsNullOrWhiteSpace(input.OrganizationId.ToString()) && currentPos.OrganizationId != input.OrganizationId)
            {
                var org = await organizationRepository.GetByIdAsync(input.OrganizationId);
                if (org == null) throw new Exception("Phòng ban mới không tồn tại!");
            }

            currentPos.Name = input.Name;
            currentPos.OrganizationId = input.OrganizationId;


            await positionRepository.UpdateAsync(currentPos);
            return true;
        }
    }
}
