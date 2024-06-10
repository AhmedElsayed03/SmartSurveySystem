using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data.EntityConfiguration
{
    public class SystemRoleConfiguration : IEntityTypeConfiguration<SystemRole>
    {
        public void Configure(EntityTypeBuilder<SystemRole> builder)
        {
            //builder.HasData(
            //    new SystemRole
            //    {

            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new SystemRole
            //    {

            //        Name = "Member",
            //        NormalizedName = "MEMBER"
            //    }
            //);
        }
    }
}
