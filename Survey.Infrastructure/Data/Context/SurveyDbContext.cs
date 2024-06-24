using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Survey.Domain.Entities;
using Survey.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data.Context
{
    public class SurveyDbContext(DbContextOptions<SurveyDbContext> options)
        : IdentityDbContext<SystemUser, SystemRole, int> (options)
    {

        //public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        //{

        //}

        public DbSet<Domain.Entities.Survey> Surveys => Set<Domain.Entities.Survey>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Choice> Choices => Set<Choice>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<MemberSurvey> MemberSurveys => Set<MemberSurvey>();
        public DbSet<Submission> Submissions => Set<Submission>();
        public DbSet<UploadedFile> Files => Set<UploadedFile>();
        public DbSet<QuestionType> QuestionTypes => Set<QuestionType>();
        public DbSet<Section> Sections => Set<Section>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<MemberSurvey>()
                .HasKey(i => new { i.MemberId, i.SurveyId });

            builder.Entity<MemberSurvey>().HasOne(i => i.Member)
                   .WithMany(i => i.MemberSurveys)
                   .HasForeignKey(i => i.MemberId);

            builder.Entity<MemberSurvey>().HasOne(i => i.Survey)
                   .WithMany(i => i.MemberSurveys)
                   .HasForeignKey(i => i.SurveyId);


            #region Mapping Strategy
            //Use Table-per-Type Strategy 
            //builder.Entity<IdentityUser>()
            //    .UseTptMappingStrategy();

            //Use Table-per-Hierarchy Strategy 
            //builder.Entity<IdentityUser>()
            //    .UseTphMappingStrategy();
            #endregion
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var allEntries = base.ChangeTracker.Entries<Entity>();

            var addedEntries = allEntries
                .Where(e => e.State == EntityState.Added);

            var editedEntries = allEntries
                .Where(e => e.State == EntityState.Modified);

            foreach (var entry in addedEntries)
            {
                entry.Entity.CreateTime = DateTime.Now;
            }

            foreach (var entry in editedEntries)
            {
                entry.Entity.UpdateTime = DateTime.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
