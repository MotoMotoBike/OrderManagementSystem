using OrderManagementSystem.Data.Repositories.Interfaces;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _repository.GetOrdersAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(long id)
    {
        return await _repository.GetOrderAsync(id);
    }

    public async Task<bool> AddOrderAsync(string name)
    {
        var order = new Order()
        {
            OrderName = name,
            OrderItem = new List<OrderItem>()
        };
        
        return await _repository.AddOrderAsync(order);
    }

    public async Task<bool> DeleteOrderAsync(long id)
    {
        var order = await _repository.GetOrderAsync(id);
        order.IsDeleted = true;
        return await _repository.UpdateOrderAsync(order);
    }
}