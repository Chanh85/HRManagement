using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string Name { get; set; } = string.Empty; // VD: "View_Employee", "Create_Employee"
        public string Description { get; set; } = string.Empty;

        // Quan hệ Nhiều-Nhiều (N-N) với Role
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
