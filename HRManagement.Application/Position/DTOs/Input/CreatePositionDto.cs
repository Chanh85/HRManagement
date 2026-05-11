using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Application.Position.DTOs.Input
{
    public class CreatePositionDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid OrganzationId { get; set; }
    }
}
