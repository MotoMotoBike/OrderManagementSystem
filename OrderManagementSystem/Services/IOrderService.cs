using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order?> GetOrderByIdAsync(long id);
    Task<bool> AddOrderAsync(string name, List<long> itemIds);
    Task<bool> DeleteOrderAsync(long id);
}
