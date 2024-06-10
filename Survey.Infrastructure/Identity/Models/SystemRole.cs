using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Models
{
    public class SystemRole : IdentityRole<int>
    {
        public SystemRole() : base()
        {

        }

        public SystemRole(string roleName) : base(roleName)
        {

        }

        // Add additional properties here if needed
    }
}
