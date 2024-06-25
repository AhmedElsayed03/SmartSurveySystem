
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Survey.Infrastructure;
using System.Security.Claims;
using System.Text;

namespace SurveySystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = builder.Configuration["JwtSettings:Authority"];
                options.Audience = builder.Configuration["JwtSettings:Audience"];

                var keyString = builder.Configuration["JwtSettings:Key"];
                var keyInBytes = Encoding.UTF8.GetBytes(keyString!);
                var key = new SymmetricSecurityKey(keyInBytes);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = key
                };
            });

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("For Members", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Member")
                    .RequireClaim(ClaimTypes.NameIdentifier);
                    //policy.RequireClaim("Role", "AppUser","other value of roles") 
                });

                options.AddPolicy("For Admins", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin")
                    .RequireClaim(ClaimTypes.NameIdentifier);
                    //policy.RequireClaim("Role", "AppUser","other value of roles") 
                });
            });

            #endregion

            #region Services
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Add Cors

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");

            #region Files Handling
            var staticFilesPath = Path.Combine(Environment.CurrentDirectory, "UploadedFiles");
            if (!Directory.Exists(staticFilesPath))
            {
                Directory.CreateDirectory(staticFilesPath);
            }
            //Configuration to let app use static files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilesPath),
                RequestPath = "/UploadedFiles" //Localhost:####/(Request Path)/Capture.PNG(Static File Name)
            });
            #endregion

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
