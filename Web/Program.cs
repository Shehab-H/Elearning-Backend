using Core.Entities.User;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Application;
using System.Security.Claims;
using Application.Enums;
using Microsoft.AspNetCore.Identity;
using Web.Controllers.User;
using Infrastructure;
using Application.Intefaces.DataStores;
using Infrastructure.Repositories;
namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            builder.Services.AddDbContext<AppDbContext>(options =>
                      options.UseSqlServer(
                      builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCors(options =>
                     options.AddDefaultPolicy(builder =>
                     builder.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod()));

            builder.Services.RegisterRepositoriesFromAssembly(typeof(InfrastructureAssemblyReference).Assembly);

            builder.Services.AddScoped<IUnitofWork, UnitOfWork>();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("TeachersOnly", policy =>
                    policy.RequireClaim(ClaimTypes.Role, UserType.Teacher.ToString()));

                options.AddPolicy("StudentsOnly", policy =>
                     policy.RequireClaim(ClaimTypes.Role, UserType.Student.ToString()));

            });

            builder.Services.AddIdentityApiEndpoints<ElearningUser>(options =>
            {
                options.User.RequireUniqueEmail=true;
            }
            )
                .AddEntityFrameworkStores<AppDbContext>();


            builder.Services.AddApplication();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<ElearningUser>() ;

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseCors();
            app.MapControllers();

            app.Run();
        }
    }
}
