using OrderManagementSystem.Domain;
using OrderManagementSystem.Domain.Abstract;

namespace OrderManagementSystem.Domain
{
    public class Order : IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }

        public string? OrderName { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal TotalPrice => Items.Sum(item => item.Quantity * item.UnitPrice);
    }
}
