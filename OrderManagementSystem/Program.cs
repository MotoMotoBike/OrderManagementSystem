using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderManagementSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext и строку подключения
builder.Services.AddDbContext<OrderManagementContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем контроллеры
builder.Services.AddControllers();

// Добавляем Swagger для тестирования API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Order Management API",
        Version = "v1",
        Description = "API for order management"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Management API v1");
        options.RoutePrefix = string.Empty; // Swagger доступен по корневому URL
    });

}

app.UseAuthorization();

app.MapControllers();

app.Run();