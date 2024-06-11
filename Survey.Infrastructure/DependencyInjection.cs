using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Survey.Application.Abstractions.Repositories;
using Survey.Application.Abstractions.Services;
using Survey.Application.Abstractions.Services.Identity;
using Survey.Application.Abstractions.UnitOfWork;
using Survey.Application.Models.Identity;
using Survey.Infrastructure.Data.Context;
using Survey.Infrastructure.Data.Repositories;
using Survey.Infrastructure.Data.UnitOfWork;
using Survey.Infrastructure.Identity.Models;
using Survey.Infrastructure.Identity.Services;
using Survey.Infrastructure.Identity.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            #region Context
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SurveyDbContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion


            #region Identity
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddIdentityCore<SystemUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<SystemRole>()
            .AddEntityFrameworkStores<SurveyDbContext>()
            .AddDefaultTokenProviders();
            #endregion


            #region Authentication Service
            services.AddScoped<IAuthService, AuthService>();
            #endregion


            #region Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISurveyRepo, SurveyRepo>();
            services.AddScoped<IQuestionRepo, QuestionRepo>();
            services.AddScoped<IChoiceRepo, ChoiceRepo>();
            services.AddScoped<IFileUploadRepo, FileUploadRepo>();
            services.AddScoped<ISubmissionRepo, SubmissionRepo>();
            services.AddScoped<IMemberSurveyRepo, MemberSurveyRepo>();
            services.AddScoped<IMemberRepo, MemberRepo>();
            services.AddScoped<IAdminRepo, AdminRepo>();
            #endregion


            #region Services
            services.AddScoped<ISurveyService, SurveyService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IChoiceService, ChoiceService>();
            services.AddScoped<IMemberSurveyService, MemberSurveyService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<ISubmissionService, SubmissionService>();
            services.AddScoped<IAdminService, AdminService>();
            #endregion


            return services;
        }
    }
}
    