using OrderManagementSystem.Data.Repositories.Interfaces;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IItemRepository _itemRepository;

    public OrderService(IOrderRepository repository, IItemRepository itemRepository)
    {
        _orderRepository = repository;
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _orderRepository.GetOrdersAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(long id)
    {
        return await _orderRepository.GetOrderAsync(id);
    }
    public async Task<bool> AddOrderAsync(string name, List<long> itemIds)
    {
        var items = await _itemRepository.GetItemsAsync(itemIds);
        
        if (items.Count != itemIds.Count)
            throw new Exception("Invalid item ids");
        
        var order = new Order
        {
            OrderName = name,
            OrderItem = new List<OrderItem>()
        };

        return await _orderRepository.AddOrderAsync(order);
    }

    public async Task<bool> DeleteOrderAsync(long id)
    {
        var order = await _orderRepository.GetOrderAsync(id);
        order.IsDeleted = true;
        return await _orderRepository.UpdateOrderAsync(order);
    }
}