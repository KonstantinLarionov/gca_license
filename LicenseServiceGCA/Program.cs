using System.Text.Json.Serialization;

using LicenseServiceGCA.Application;
using LicenseServiceGCA.Application.AuthorizeOptions;
using LicenseServiceGCA.Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers()
	.AddJsonOptions( o =>
	{
		o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
	} );

builder.Services.AddApplication();
builder.Services.AddInfrastructureDataBase( builder.Configuration );
#if DEBUG
builder.Services.AddTestAdminData(builder.Configuration);//MyTestData
#endif

#region Swagger Configuration

builder.Services.AddSwaggerGen( swagger =>
{
	//This is to generate the Default UI of Swagger Documentation
	swagger.SwaggerDoc( "v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "JWT Token Authentication API",
		Description = "ASP.NET Core 5.0 Web API"
	} );
	// To Enable authorization using Swagger (JWT)
	swagger.AddSecurityDefinition( "Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description =
			"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
	} );
	swagger.AddSecurityRequirement( new OpenApiSecurityRequirement
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
			new string[] { }
		}
	} );
} );
#endregion
#region Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = AuthOptions.ISSUER,
			ValidateAudience = true,
			ValidAudience = AuthOptions.AUDIENCE,
			ValidateLifetime = true,
			IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
			ValidateIssuerSigningKey = true,
		};
	});
#endregion
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "FractalzBackend");
		//c.RoutePrefix = string.Empty;
	});
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();

app.MapControllers();

app.Run();
