using ItemManagementSystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.Repositories;
using OrderManagementSystem.Data.Repositories.Interfaces;
using OrderManagementSystem.Services;
using OrderManagementSystem.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<OrderManagementContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IItemService, ItemService>();

//Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddControllers().AddNewtonsoftJson();

//Swagger
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Management API v1");
        options.RoutePrefix = string.Empty;
    });

}
app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();