using CompanyManagment.Models;
using CompanyManagment.Repositiors;
using CompanyManagment.Repositiors.Interfaces;
using CompanyManagment.Services;
using CompanyManagment.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace CompanyManagment
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// ----------------------------
			// 🔹 Add Services to Container
			// ----------------------------

			// Database Configuration
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			// Dependency Injection (Repositories & Services)
			builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			builder.Services.AddScoped<IDepartmentService, DepartmentService>();
			builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			builder.Services.AddScoped<IEmployeeService, EmployeeService>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IAuthService, AuthService>();




			builder.Services.AddControllers()
	       .AddJsonOptions(x =>
		x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

			// Controllers
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();

			// ----------------------------
			//  JWT Authentication Setup
			// ----------------------------
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					var key = builder.Configuration["Jwt:Key"];
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!))
					};
				});

			// ----------------------------
			//  CORS Policy
			// ----------------------------
			builder.Services.AddCors(options =>
			{
				options.AddDefaultPolicy(policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyHeader()
						  .AllowAnyMethod();
				});
			});

			// ----------------------------
			//  Swagger + JWT Integration
			// ----------------------------
			builder.Services.AddSwaggerGen(swagger =>
			{
				swagger.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "ASP.NET 8 Web API",
					Description = "CompanyManagment"
				});

				swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Enter 'Bearer' followed by a space and your token.\r\n\r\nExample: \"Bearer eyJhbGciOi...\""
				});

				swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						Array.Empty<string>()
					}
				});
			});

			// ----------------------------
			//  Build & Configure App
			// ----------------------------
			var app = builder.Build();

			try
			{
				using (var scope = app.Services.CreateScope())
				{
					var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

					if (!context.Users.Any())
					{
						using var hmac = new HMACSHA256();
						var password = "Admin@123";
						var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
						var salt = hmac.Key;

						context.Users.Add(new User
						{

							UserName = "admin",
							PasswordHash = hash,
							passwardSlat = salt
						});


						context.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "saleh");
			}
			// Global Exception Handling
			app.UseExceptionHandler(config =>
			{
				config.Run(async context =>
				{
					context.Response.StatusCode = 500;
					context.Response.ContentType = "application/json";
					await context.Response.WriteAsync("{\"error\": \"An unexpected error occurred.\"}");
				});
			});

			app.UseHttpsRedirection();
			app.UseCors();              // Must come after Build
			app.UseAuthentication();    // JWT
			app.UseAuthorization();     // JWT

			app.UseSwagger();
			app.UseSwaggerUI();

			app.MapControllers();
			app.Run();
		}
	}
}
