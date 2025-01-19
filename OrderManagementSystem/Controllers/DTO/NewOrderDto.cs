using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Controllers.DTO;

public class NewOrderDto
{
    
    [Required(ErrorMessage = "ItemIds is required")]
    public List<OrderItemDto>? ItemIds { get ; set; }
}