using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Services;


[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _service;

    public ItemsController(IItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        try
        {
            var Items = await _service.GetItemsAsync();
            return Ok(Items);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message} {ex.StackTrace}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(string itemName, decimal price)
    {
        try
        {
            var items = await _service.AddItemAsync(itemName, price);
            return Ok(items);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message} {ex.StackTrace}");
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteItem(long id)
    {
        try
        {
            var Items = await _service.DeleteItemAsync(id);
            return Ok(Items);
        }
        catch (Exception ex)
        {
            return BadRequest($"{ex.Message} {ex.StackTrace}");
        }
    }
}