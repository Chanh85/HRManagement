using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Name { get; set; } = string.Empty; // VD: Admin, Manager, Staff
        public string Description { get; set; } = string.Empty;

        // 1 Role có nhiều Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        // Quan hệ Nhiều-Nhiều (N-N) với Permission
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
