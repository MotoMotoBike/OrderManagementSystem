using OrderManagementSystem.Domain;

public interface IItemRepository
{
    Task<List<Item>> GetItemsAsync();
    Task<List<Item>> GetItemsAsync(List<long> ids);
    Task<Item?> GetItemAsync(long id);
    Task<bool> AddItemAsync(Item Item);
    Task<bool> UpdateItemAsync(Item? Item);
}