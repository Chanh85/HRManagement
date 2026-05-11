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
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Success(employees, HttpStatusCode.OK, "Lấy danh sách thành công");
    }
    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        try
        {
            await _employeeService.CreateEmployeeAsync(employee);
            return Success("Data created", HttpStatusCode.OK, "Tạo thành công");
        }
        catch (Exception ex)
        {
            return Error<string>("Có lỗi xảy ra", ex.Message, HttpStatusCode.NotFound);
        }
    }
}
