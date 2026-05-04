using HRManagement.Application.Organization.DTOs.Input;
using HRManagement.Application.Organization.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationController(IOrganizationService _service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null) return NotFound("Phòng ban không tồn tại");
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrganizationDto dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(201, "Tạo phòng ban thành công");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrganizationDto dto)
    {
        if (id != dto.Id) return BadRequest("ID không khớp!");

        try
        {
            await _service.UpdateAsync(dto);
            return Ok("Cập nhật thành công");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return Ok("Xóa thành công");
        }
        catch (Exception ex)
        {
            // Nếu xoá phòng ban đang có nhân viên, EF Core sẽ ném lỗi. Bắt nó ở đây!
            return BadRequest("Lỗi: " + ex.Message);
        }
    }
}
