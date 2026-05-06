using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Common
{
    public class ApiResponse<T>
    {
        // Đổi Success (bool) thành Status (string "OK" hoặc "NOTOK")
        public string Status { get; set; } = string.Empty;

        // Thêm StatusCode (Ví dụ: 200, 201, 400, 404, 500...)
        public int StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }

        // Đổi Errors (List) thành Error (string) để chứa chi tiết lỗi
        public string? Error { get; set; }

        // Hàm tĩnh để tạo response THÀNH CÔNG (Mặc định HTTP 200)
        public static ApiResponse<T> Succeeded(T data, string message = "Thành công", int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Status = "OK",
                StatusCode = statusCode,
                Message = message,
                Data = data,
                Error = null
            };
        }

        // Hàm tĩnh để tạo response THẤT BẠI (Mặc định HTTP 400)
        public static ApiResponse<T> Failed(string message, string? error = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                Status = "NOTOK",
                StatusCode = statusCode,
                Message = message,
                Data = default, // null
                Error = error
            };
        }
    }
}
