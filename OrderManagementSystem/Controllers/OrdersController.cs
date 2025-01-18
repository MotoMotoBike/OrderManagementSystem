using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Controllers.DTO;
using OrderManagementSystem.Domain;
using OrderManagementSystem.Services;
using OrderManagementSystem.Services.Abstract;

namespace OrderManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        try
        {
            var orders = await _service.GetOrdersAsync();
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message} {ex.StackTrace}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(string orderName, List<OrderItemDto> itemIds)
    {
        try
        {
            var orders = await _service.AddOrderAsync(orderName, itemIds);
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message} {ex.StackTrace}");
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrder(long id)
    {
        try
        {
            var orders = await _service.DeleteOrderAsync(id);
            return Ok(orders);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message} {ex.StackTrace}");
        }
    }
}