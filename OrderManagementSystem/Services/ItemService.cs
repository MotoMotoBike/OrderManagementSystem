using OrderManagementSystem.Domain;
using OrderManagementSystem.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _repository.GetItemsAsync();
    }

    public async Task<Item?> GetItemByIdAsync(long id)
    {
        return await _repository.GetItemAsync(id);
    }

    public async Task<bool> AddItemAsync(string name, decimal price)
    {
        var Item = new Item
        {
            ProductName = name,
            UnitPrice = price
        };

        return await _repository.AddItemAsync(Item);
    }

    public async Task<bool> DeleteItemAsync(long id)
    {
        var item = await _repository.GetItemAsync(id);
        item.IsDeleted = true;
        return await _repository.UpdateItemAsync(item);
    }
}