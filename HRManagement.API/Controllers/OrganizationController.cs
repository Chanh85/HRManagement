using HRManagement.Application.Common;
using HRManagement.Application.Organization.DTOs.Input;
using HRManagement.Application.Organization.DTOs.Output;
using HRManagement.Application.Organization.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HRManagement.API.Controllers;

[Route("api/[controller]")]
public class OrganizationController(IOrganizationService _service) : AppControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        // Dùng hàm Success kế thừa từ Base, trả về 200 OK
        return Success(result, HttpStatusCode.OK, "Lấy danh sách thành công");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
            return Error<string>("Phòng ban không tồn tại", null, HttpStatusCode.NotFound); // Trả về 404

        return Success(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrganizationDto dto)
    {
        await _service.CreateAsync(dto);
        // Trả về mã 201 (Created)
        return Success("Data Created", HttpStatusCode.Created, "Tạo phòng ban thành công");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateOrganizationDto dto)
    {
        if (id != dto.Id) return Error<string>("ID không khớp", null, HttpStatusCode.BadRequest);

        try
        {
            await _service.UpdateAsync(dto);
            return Success("Update success");
        }
        catch (Exception ex)
        {
            return Error<string>("Có lỗi xảy ra", ex.Message, HttpStatusCode.NotFound);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return Success("Deleted", HttpStatusCode.OK, "Xóa thành công");
        }
        catch (Exception ex)
        {
            // Trả về 400 (BadRequest) kèm chi tiết lỗi
            return Error<string>("Không thể xóa phòng ban", ex.Message, HttpStatusCode.BadRequest);
        }
    }
}
