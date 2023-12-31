using ArtAPI.Services;
using ArtCommissions.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<PostgresContext>(config => config.UseNpgsql(builder.Configuration["db"]));
builder.Services.AddScoped<ICommissionService, CommissionRequestService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddHttpClient();




var app = builder.Build();
var emailpassword = builder.Configuration["mailpassword"];

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
