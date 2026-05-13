using HRManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Employee.DTOs.Input
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; // Họ và tên
        public string Code { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Email cá nhân
        public string? OtherEmail { get; set; } // Email khác
        public Guid? AvatarFileId { get; set; } // Ảnh đại diện
        public string PhoneNumber { get; set; } = string.Empty; // Số điện thoại cá nhân
        public DateTime? JoinedDate { get; set; } // Ngày vào
        public DateTime? DateOfBirth { get; set; } // Ngày sinh
        public bool IsFirstLogin { get; set; } // Lần đầu đăng nhập ?

        public Guid OrganizationUnitId { get; set; } // Phòng ban

        public Guid PositionId { get; set; } // Chức vụ trong phòng ban
    }
}
