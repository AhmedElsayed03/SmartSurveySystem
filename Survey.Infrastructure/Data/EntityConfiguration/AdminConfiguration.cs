using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Entities;
using Survey.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data.EntityConfiguration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(i => i.Id);
            //builder.Property(i => i.Id)
            //       .ValueGeneratedNever();
            builder.HasOne<SystemUser>()
                   .WithOne()
                   .HasForeignKey<Admin>(c => c.Id);



            //var students = Enumerable.Range(1, 20)
            //       .Select(i => new Member
            //       {
            //           //Id = i,
            //           //CreationTime = DateTime.Now,
            //           //ProfilePhoto = $"https://picsum.photos/20{i}",
            //           //UserId = SeedingHelper.StudentsGuids[i - 1],
            //       });

            //builder.HasData(students);


        }
    }
}
