using FluentValidation;
using FluentValidation.AspNetCore;
using ShoeService.BL;
using ShoeService.DL;
using ShoeService.Host.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ShoeService.Host.Validators.ShoeValidator>();

// Register DL and BL layers
builder.Services.RegisterDL();
builder.Services.RegisterBL();

// Register Mapster mappings
MapsterConfig.RegisterMappings();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add HealthChecks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
