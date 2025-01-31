using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Services.Abstract;

public interface IItemService
{
    Task<List<Item>> GetItemsAsync();
    Task<Item?> GetItemByIdAsync(long id);
    Task<bool> AddItemAsync(string? name, decimal price);
    Task<bool> DeleteItemAsync(long id);
}