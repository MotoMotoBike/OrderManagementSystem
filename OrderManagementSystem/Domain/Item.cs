using OrderManagementSystem.Domain.Abstract;

namespace OrderManagementSystem.Domain;

public class Item : IEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    
    public string? ProductName { get; set; }
    public decimal UnitPrice { get; set; }
}