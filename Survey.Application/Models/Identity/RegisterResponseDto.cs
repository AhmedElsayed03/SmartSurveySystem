using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.Identity
{
    public class RegisterResponseDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public IEnumerable<string>? Role { get; set; }

        public RegisterResponseDto(int userId, string userName, string firstName, string lastName, string email, IEnumerable<string>? role)
        {

            UserId = userId;
            UserName = userName;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }
}