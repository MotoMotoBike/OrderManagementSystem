using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Domain;

namespace ItemManagementSystem.Data.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly OrderManagementContext _context;

    public ItemRepository(OrderManagementContext context)
    {
        _context = context;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        return await _context.Get<Item>().ToListAsync();
    }

    public async Task<Item?> GetItemAsync(long id)
    {
        return await _context.Get<Item>().FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task<List<Item>> GetItemsAsync(List<long> ids)
    {
        return await _context.Get<Item>().Where(o => ids.Contains(o.Id)).ToListAsync();
    }

    public async Task<bool> AddItemAsync(Item item)
    {
        await _context.Create(item);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateItemAsync(Item? item)
    {
        _context.Update(item);
        return await _context.SaveChangesAsync() > 0;
    }
}