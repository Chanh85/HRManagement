using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Organization.DTOs.Input
{
    public class UpdateOrganizationDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
