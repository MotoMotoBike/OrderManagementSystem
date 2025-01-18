using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Controllers.DTO;

public class NewItemDto
{
    [Required]
    public string? ItemName { get; set; }
    [Required]
    public decimal Price { get; set; }
}