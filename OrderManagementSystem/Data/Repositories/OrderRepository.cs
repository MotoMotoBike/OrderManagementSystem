using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data.Repositories.Interfaces;
using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderManagementContext _context;

    public OrderRepository(OrderManagementContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await _context.Orders.Include(o => o.OrderItem).ToListAsync();
    }

    public async Task<Order> GetOrderAsync(long id)
    {
        return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<bool> AddOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteOrderAsync(Order order)
    {
        _context.Orders.Remove(order);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteOrderAsync(long id)
    {
        var order = await GetOrderAsync(id);
        if (order == null) throw new Exception("Order not found");
        _context.Orders.Remove(order);
        return await _context.SaveChangesAsync() > 0;
    }
}