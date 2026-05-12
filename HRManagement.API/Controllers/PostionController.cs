using HRManagement.Application.Position.DTOs.Input;
using HRManagement.Application.Position.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HRManagement.API.Controllers;

[Route("api/[controller]")]
public class PostionController(IPositionService positionService) : AppControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await positionService.GetAsync();
        return Success(result, HttpStatusCode.OK, "Lấy danh sách thành công");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await positionService.GetByIdAsync(Id);
        return Success(result, HttpStatusCode.OK);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePositionDto dto)
    {
        try
        {
            await positionService.CreateAsync(dto);
            return Success("Data Created", HttpStatusCode.Created, "Tạo chức vụ thành công");
        }
        catch (Exception ex)
        {
            return Error<string>(ex.Message, null, HttpStatusCode.BadRequest);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(UpdatePositionDto dto)
    {
        try
        {
            var result = await positionService.UpdateAsync(dto);
            return Success(result, HttpStatusCode.OK, "Cập nhật thành công");
        }
        catch(Exception ex)
        {
            return Error<string>(ex.Message, null, HttpStatusCode.BadRequest);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        try
        {
             await positionService.DeleteAsync(id);
            return Success("Deleted", HttpStatusCode.OK, "Xóa thành công");
        }
        catch (Exception ex)
        {
            return Error<string>("Không thể xóa chức vụ", ex.Message, HttpStatusCode.BadRequest);
        }

    }
}
