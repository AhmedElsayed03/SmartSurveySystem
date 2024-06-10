using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class MemberAddDto
    {
        public int Age { get; set; }
        public string Location { get; set; } = string.Empty;
        public int UserId { get; set; } //Foreign Key from the Identity Table
    }
}
