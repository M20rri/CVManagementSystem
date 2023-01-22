using CVManagementSystem.Context;
using CVManagementSystem.Interface;
using CVManagementSystem.Interface.Implementation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CVManagementSystem.Extensions
{
    public static class ConfigExtension
    {
        public static void AddDIContainer(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();

            builder.Services.AddScoped<IPersonalInformation, PersonalInformationRepository>();
            builder.Services.AddScoped<IExperienceInformation, ExperienceInformationRepository>();
            builder.Services.AddScoped<ICV, CVRepository>();
            builder.Services.AddDbContext<CVContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSwaggerGen(options =>
            {
                // Adding swagger document
                options.SwaggerDoc("v1.0", new OpenApiInfo() { Title = "CV API v1.0", Version = "v1.0" });


                // To use unique names with the requests and responses
                options.CustomSchemaIds(x => x.FullName);

                // Defining the security schema
                var securitySchema = new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                // Adding the bearer token authentaction option to the ui
                options.AddSecurityDefinition("Bearer", securitySchema);

                // use the token provided with the endpoints call
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                });

            });
        }
    }
}
