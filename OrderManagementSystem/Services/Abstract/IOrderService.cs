using OrderManagementSystem.Controllers.DTO;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Services.Abstract;

public interface IOrderService
{
    Task<List<Order>> GetOrdersAsync();
    Task<Order?> GetOrderByIdAsync(long id);
    Task<bool> AddOrderAsync(string name, List<OrderItemDto> items);
    Task<bool> DeleteOrderAsync(long id);
}
