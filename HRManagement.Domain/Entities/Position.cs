using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Position
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string? Name { get; set; } // Tên chức vụ
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Khoá ngoại (Foreign Key) trỏ về Organization
        public Guid OrganizationId { get; set; }
        public OrganizationUnit? Organization { get; set; } // Navigation property

        // 1 Chức vụ có thể có nhiều Nhân viên đảm nhận
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
