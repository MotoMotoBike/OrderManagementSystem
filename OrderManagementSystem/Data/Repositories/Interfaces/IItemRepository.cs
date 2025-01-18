using OrderManagementSystem.Domain;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<Item> GetItemAsync(long id);
    Task<bool> AddItemAsync(Item Item);
    Task<bool> UpdateItemAsync(Item Item);
}