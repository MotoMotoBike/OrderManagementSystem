namespace OrderManagementSystem.Domain.Abstract;

public interface IEntity
{
    long Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime ModifiedAt { get; set; }
    bool IsDeleted { get; set; }
}