
using MediatR;
using FanEase.Repository;
using FanEase.Middleware;
using FanEase.ExceptionHandling.Aspect_Oriented_Programming;

using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.RespectBrowserAcceptHeader = true) ;
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.RegisterRepositoryLayer();
builder.Services.RegisterMiddlewareLayer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Logging.AddLog4Net("log4net.config");




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
