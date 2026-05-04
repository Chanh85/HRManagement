using HRManagement.Application.Employee.Interfaces;
using HRManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService _employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Employee employee)
    {
        try
        {
            await _employeeService.CreateEmployeeAsync(employee);
            return StatusCode(201, "Tạo nhân viên thành công");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
