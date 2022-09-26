using Business.Abstract;
using Business.Concrete;
using Business.Mapping.AutoMapper;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Data.SqlClient;
using Shared.Utilities.Security;
using Shared.Utilities.Service;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


//IConfiguration config = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json",false,true)
//    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
//    .Build();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataProtection();
builder.Services.AddSingleton<DataHashingHelper>();

//IoC
builder.Services.AddScoped<IUserDAL, UserDAL>();
builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddAutoMapper(x => x.AddProfile<AutoMapperMappingProfile>());


builder.Services.AddTransient<IDbConnection>(build =>
new SqlConnection(builder.Configuration.GetConnectionString("default")));


ServiceCollectionHelper.Create(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
