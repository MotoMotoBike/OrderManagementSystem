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

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await _context.Get<Order>().Include(o => o.OrderItem).ToListAsync();
    }

    public async Task<Order?> GetOrderAsync(long id)
    {
        return await _context.Get<Order>().FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<bool> AddOrderAsync(Order order)
    {
        await _context.Create(order);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateOrderAsync(Order? order)
    {
        _context.Update(order);
        return await _context.SaveChangesAsync() > 0;
    }
}