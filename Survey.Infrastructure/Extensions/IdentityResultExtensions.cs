using Microsoft.AspNetCore.Identity;
using Survey.Application.Execptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Extensions
{
    public static class IdentityResultExtensions
    {
        public static void ThrowIfFailed(this IdentityResult result, string message)
        {
            if (!result.Succeeded)
            {
                var errors = result.Errors
                    .ToDictionary(e => e.Code, e => e.Description);
                throw new BadRequestException(message, errors);
            }
        }
    }
}
