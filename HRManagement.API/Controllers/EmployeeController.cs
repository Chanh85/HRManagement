using HRManagement.Application.Employee.DTOs.Input;
using HRManagement.Application.Employee.Interfaces;
using HRManagement.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HRManagement.API.Controllers;

[Route("api/[controller]")]
public class EmployeeController(IEmployeeService _employeeService) : AppControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Success(employees, HttpStatusCode.OK, "Lấy danh sách thành công");
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var employee = await _employeeService.GetEmployeeById(Id);
        return Success(employee, HttpStatusCode.OK);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEmployeeDto employee)
    {
        try
        {
            await _employeeService.CreateEmployeeAsync(employee);
            return Success("Data created", HttpStatusCode.Created, "Tạo thành công");
        }
        catch (ArgumentException ex)
        {
            return Error<string>("Dữ liệu không hợp lệ", ex.Message, HttpStatusCode.BadRequest);
        }
        catch (InvalidOperationException ex)
        {
            return Error<string>("Không thể tạo nhân viên", ex.Message, HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return Error<string>("Có lỗi xảy ra", ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateAsync(Guid Id, UpdateEmployeeDto dto)
    {
        if (Id != dto.Id) return Error<string>("ID không khớp", null, HttpStatusCode.BadRequest);
        try
        {
            bool result = await _employeeService.UpdateEmployeeAsync(dto);
            return Success(result, HttpStatusCode.OK, "Cập nhật thành công");
        }
        catch (ArgumentException ex)
        {
            return Error<string>("Dữ liệu không hợp lệ", ex.Message, HttpStatusCode.BadRequest);
        }
        catch (InvalidOperationException ex)
        {
            return Error<string>("Không thể tạo nhân viên", ex.Message, HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return Error<string>("Có lỗi xảy ra", ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteAsync(Guid Id)
    {
        try
        {
            await _employeeService.DeleteEmployeeAsync(Id);
            return Success("Deleted", HttpStatusCode.OK, "Xóa thành công");
        }
        catch (Exception ex)
        {
            // Trả về 400 (BadRequest) kèm chi tiết lỗi
            return Error<string>("Không thể xóa phòng ban", ex.Message, HttpStatusCode.BadRequest);
        }
    }
}
