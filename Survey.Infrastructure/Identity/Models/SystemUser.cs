using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Models
{
    public class SystemUser : IdentityUser<int>
    {
        //Extend then add properties
        //Add Mutual properties between all users and doesn't exist in Identity User
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}
