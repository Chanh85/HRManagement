using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Name { get; set; } = string.Empty; // Họ và tên
        public string Code { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Email cá nhân
        public string? OtherEmail { get; set; } // Email khác
        public Guid? AvatarFileId { get; set; } // Ảnh đại diện
        public string PhoneNumber { get; set; } = string.Empty; // Số điện thoại cá nhân
        public DateTime? JoinedDate { get; set; } // Ngày vào
        public DateTime? DateOfBirth { get; set; } // Ngày sinh
        public bool IsFirstLogin { get; set; } // Lần đầu đăng nhập ?

        // Khoá ngoại trỏ về Phòng ban
        public Guid? OrganizationUnitId { get; set; } // Phòng ban
        public OrganizationUnit? Organization { get; set; }

        // Khoá ngoại trỏ về Chức vụ
        public Guid? PositionId { get; set; } // Chức vụ trong phòng ban
        public Position? Position { get; set; }
    }
}
