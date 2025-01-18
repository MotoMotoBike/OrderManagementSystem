using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Data.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersAsync();
    Task<Order?> GetOrderAsync(long id);
    Task<bool> AddOrderAsync(Order order);
    Task<bool> UpdateOrderAsync(Order? order);
}