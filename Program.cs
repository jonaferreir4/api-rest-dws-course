using api_rest.Domain.Repositories;
using api_rest.Domain.Services;
using api_rest.Persistence.Context;
using api_rest.Persistence.Repositories;
using api_rest.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseInMemoryDatabase("supermarket-api-in-memory");
});

// Correção dos nomes das interfaces:
builder.Services.AddScoped<ICategoryRespository, CategoryRespository>();
builder.Services.AddScoped<ICatogoryService, CategoryService>();

// Swagger (opcional):
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); // Adicionado!
app.UseAuthorization();
app.MapControllers();

app.Run();