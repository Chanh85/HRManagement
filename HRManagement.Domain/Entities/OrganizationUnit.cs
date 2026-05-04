using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class OrganizationUnit
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string DisplayName { get; set; } = string.Empty; // Tên hiển thị của phòng ban
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property: 1 Phòng ban có nhiều Chức vụ và Nhân viên
        public ICollection<Position> Positions { get; set; } = new List<Position>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
