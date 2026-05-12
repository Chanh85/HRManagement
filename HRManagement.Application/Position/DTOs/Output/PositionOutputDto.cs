using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Position.DTOs.Output
{
    public class PositionOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid OrganizationId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
    }
}
