using Newtonsoft.Json;
using OrderManagementSystem.Domain.Abstract;

namespace OrderManagementSystem.Domain;

public class OrderItem : IEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
    public int Quantity { get; set; }
    public long OrderId { get; set; }
    [JsonIgnore]
    public Order? Order { get; set; }
    public long ItemId { get; set; }
    [JsonIgnore]
    public Item? Item { get; set; }
}