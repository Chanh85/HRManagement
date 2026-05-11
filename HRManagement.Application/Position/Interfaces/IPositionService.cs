using HRManagement.Application.Position.DTOs.Input;
using HRManagement.Application.Position.DTOs.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Position.Interfaces
{
    public interface IPositionService
    {
        Task CreateAsync(CreatePositionDto input);
        Task UpdateAsync(UpdatePositionDto input);
        Task DeleteAsync(Guid id);
        Task<PositionOutputDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<PositionOutputDto>> GetAsync();
    }
}
