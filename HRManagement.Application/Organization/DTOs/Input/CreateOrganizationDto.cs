using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Organization.DTOs.Input
{
    public class CreateOrganizationDto
    {
        public string DisplayName { get; set; } = string.Empty; // Tên hiển thị của phòng ban
        public string Description { get; set; } = string.Empty;
    }
}
