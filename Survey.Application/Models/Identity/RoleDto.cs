using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.Identity
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public RoleDto()
        {
            
        }
        public RoleDto(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }
    }
}
