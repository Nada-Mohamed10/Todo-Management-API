using Microsoft.EntityFrameworkCore;
using Todo_Management_API.Mapping;
using Todo_Management_API.Models;
using Todo_Management_API.Repositries;
using Todo_Management_API.Service;
using Todo_Management_API.Unit_of_works;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// add Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// add UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// add Services
builder.Services.AddScoped<ITodoService, TodoService>();

// add Repositories
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
// add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// mapping the TodoService
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
      
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
