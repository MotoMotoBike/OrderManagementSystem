using OrderManagementSystem.Domain;

namespace OrderManagementSystem.Services;

public interface IItemService
{
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<Item?> GetItemByIdAsync(long id);
    Task<bool> AddItemAsync(string name, decimal price);
    Task<bool> DeleteItemAsync(long id);
}