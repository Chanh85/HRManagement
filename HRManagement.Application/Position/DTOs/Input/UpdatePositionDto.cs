using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Position.DTOs.Input
{
    public class UpdatePositionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid OrganizationId { get; set; }
    }
}
