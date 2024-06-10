using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.Identity
{
    public class TokenDto
    {
        public string Token { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
    }
}
