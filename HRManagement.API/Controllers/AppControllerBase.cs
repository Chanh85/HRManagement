using HRManagement.Application.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HRManagement.API.Controllers;

[ApiController]
public abstract class AppControllerBase : ControllerBase
{
    // Hàm gói dữ liệu THÀNH CÔNG (Hỗ trợ 200, 201, 204...)
    protected IActionResult Success<T>(T data, HttpStatusCode code = HttpStatusCode.OK, string message = "Thành công")
    {
        // 1. Tạo hộp quà Base Response
        var response = ApiResponse<T>.Succeeded(data, message, (int)code);

        // 2. Trả về đúng mã HTTP động
        return StatusCode((int)code, response);
    }

    // Hàm gói dữ liệu THẤT BẠI (Hỗ trợ 400, 401, 403, 404, 500, 502...)
    protected IActionResult Error<T>(string message, string? errorDetail = null, HttpStatusCode code = HttpStatusCode.BadRequest)
    {
        // 1. Tạo hộp quà lỗi
        var response = ApiResponse<T>.Failed(message, errorDetail, (int)code);

        // 2. Trả về đúng mã HTTP động
        return StatusCode((int)code, response);
    }
}
