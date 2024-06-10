using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.Identity
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Key { get; set; } = string.Empty;
        public double DurationInMinutes { get; set; }
    }
}
