using Business.Abstract;
using Business.Concrete;
using Business.Mapping.AutoMapper;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using Shared.Utilities.Security;
using Shared.Utilities.Service;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
    .Build();






builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Base Project API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
  {
    {
      new OpenApiSecurityScheme
      {
        Reference = new OpenApiReference
        {
          Type = ReferenceType.SecurityScheme,
          Id = "Bearer"
        },
        Scheme = "oauth2",
        Name = "Bearer",
        In = ParameterLocation.Header,

      },
      new List<string>()
    }});
});

builder.Services.AddDataProtection();
builder.Services.AddSingleton<DataHashingHelper>();

//IoC
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddAutoMapper(x => x.AddProfile<AutoMapperMappingProfile>());


builder.Services.AddTransient<IDbConnection>(build => new SqlConnection(builder.Configuration.GetConnectionString("default")));


IoCHelper.Create(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
