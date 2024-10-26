using Asp.Versioning;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Minekom.Core;
using Minekom.Domain.Configuration;
using Minekom.Infrastructure;
using Minekom.Infrastructure.Data.EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;
using Autofac.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Minekom.API.Swagger;
using Minekom.API.Middlewares;
using Swashbuckle.AspNetCore;


namespace Minekom.API;

[ExcludeFromCodeCoverage]
internal static class Program
{

    public static async Task Main(string[] p_Args)
    {
        WebApplicationBuilder v_Builder = WebApplication.CreateBuilder(p_Args);

        string v_ConnectionString =
            v_Builder.Configuration.GetConnectionString("Minekom");
        string v_XmlCommentsFilePath =
            $"{AppDomain.CurrentDomain.BaseDirectory}{Path.DirectorySeparatorChar}{typeof(Program).Assembly.GetName().Name}.xml";

        // Autofac for module registration
        v_Builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        v_Builder.Host.ConfigureContainer<ContainerBuilder>(p_Builder =>
        {
            p_Builder.RegisterModule<ApiModule>(); //from API itself
            p_Builder.RegisterModule<CoreModule>(); //from core library
            p_Builder.RegisterModule<InfrastructureModule>(); //from infrastructure library
        });

        // Add services to the container.
        v_Builder.Services.AddValidatorsFromAssemblyContaining<ApiModule>();
        v_Builder.Services.AddMediatR(p_Config => p_Config.RegisterServicesFromAssembly(typeof(CoreModule).Assembly));
        v_Builder.Services.AddControllers()
            .AddJsonOptions(p_Options =>
            {
                // To enable display of enums as string
                p_Options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                p_Options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            }
            );

        // Swagger
        v_Builder.Services.AddEndpointsApiExplorer();

        v_Builder.Services
            .AddApiVersioning(p_O =>
            {
                p_O.AssumeDefaultVersionWhenUnspecified = true;
                p_O.DefaultApiVersion = new ApiVersion(1, 0);
                p_O.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

        v_Builder.Services.AddApiVersioning().AddApiExplorer(p_O =>
        {
            p_O.GroupNameFormat = "'v'VVV";
            p_O.SubstituteApiVersionInUrl = true;
        });

        
        v_Builder.Services.AddSwaggerGen(p_X =>
        {
            // integrate xml comments
            //p_X.IncludeXmlComments(v_XmlCommentsFilePath);

            p_X.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field your Jwt",
                    Name = HeaderNames.Authorization,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

            p_X.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                }
            );
        });
        v_Builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

        // EF Core
        v_Builder.Services.AddDbContext<MinekomContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(v_ConnectionString, new MariaDbServerVersion(new Version(11, 2, 2)))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

        // AutoMapper
        v_Builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(CoreModule).Assembly,
            typeof(InfrastructureModule).Assembly);

        // Authentication
        JwtConfiguration v_JwtConf = new();

        v_Builder.Configuration.Bind(JwtConfiguration.SectionName, v_JwtConf);

        v_Builder.Services.AddSingleton(v_JwtConf);

        
        v_Builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                p_O => p_O.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = v_JwtConf.Issuer,
                    ValidAudience = v_JwtConf.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(v_JwtConf.Key)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                });
        // CORS
        v_Builder.Services.AddCors(static options =>
        {
            options.AddDefaultPolicy(
                static policy =>
                {
#pragma warning disable S5122 //we accept any origin for this api
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
#pragma warning disable S5122
                }
            );
        });

        WebApplication v_App = v_Builder.Build();

        // Configure the HTTP request pipeline.
        if (v_App.Environment.IsDevelopment())
        {
            v_App.UseSwagger();
            v_App.UseSwaggerUI();
        }

        v_App.UseHttpsRedirection();

        v_App.UseCors();

        v_App.UseRouting();

        v_App.UseAuthentication();
        v_App.UseAuthorization();

        v_App.UseMiddleware<HandleExceptionMiddleware>();

        v_App.MapControllers();


        await v_App.RunAsync();
    }
}