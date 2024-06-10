using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Execptions
{
    public class BadRequestException(string message, Dictionary<string, string>? errors = null)
    : Exception(message)
    {
        public Dictionary<string, string>? Errors { get; set; } = errors;
    }
}
