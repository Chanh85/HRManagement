using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Organization.DTOs.Output
{
    public class OrganizationOutputDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
