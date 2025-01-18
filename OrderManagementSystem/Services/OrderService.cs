using OrderManagementSystem.Controllers.DTO;
using OrderManagementSystem.Data.Repositories.Interfaces;
using OrderManagementSystem.Domain;
using OrderManagementSystem.Services.Abstract;

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

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _orderRepository.GetOrdersAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(long id)
    {
        return await _orderRepository.GetOrderAsync(id);
    }
    public async Task<bool> AddOrderAsync(string name, List<OrderItemDto> items)
    {
        var dbItems = await _itemRepository.GetItemsAsync(items.Select(x => x.ItemId).ToList());
        
        if (dbItems.Count != items.Count)
            throw new Exception("Invalid item ids");
        
        var orderItems = dbItems.Select(dbItem => new OrderItem
        {
            Item = dbItem,
            Quantity = items.First(x => x.ItemId == dbItem.Id).Quantity
        }).ToList();
        
        var order = new Order
        {
            OrderName = name,
            OrderItem = orderItems
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