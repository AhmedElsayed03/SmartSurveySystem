using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.Identity
{
    public class AuthResponseDto
    {
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiryDateTime { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    //public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsEmailVerified { get; set; }
    public IEnumerable<string>? Role { get; set; }

        public AuthResponseDto(string token, DateTime expiryDateTime, int userId, string userName,/* string firstName, string lastName,*/ IEnumerable<string>? role)
        {
            Token = token;
            ExpiryDateTime = expiryDateTime;
            UserId = userId;
            UserName = userName;
            //Email = email;
            //FirstName = firstName;
            //LastName = lastName;
            Role = role;
        }
    }
}
