using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class AdminAddDto
    {
        public string JobTitle { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int UserId { get; set; } //Foreign Key from the Identity Table
    }
}
