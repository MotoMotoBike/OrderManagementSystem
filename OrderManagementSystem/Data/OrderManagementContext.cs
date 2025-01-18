using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain;
using OrderManagementSystem.Domain.Abstract;

namespace OrderManagementSystem.Data;

public class OrderManagementContext : DbContext
{
    public OrderManagementContext(DbContextOptions<OrderManagementContext> options) : base(options)
    {
    }

    public DbSet<Order>? Orders { get; set; }
    public DbSet<Item>? Items { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderManagementContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (IEntity)entry.Entity;

            if (entry.State == EntityState.Added) entity.CreatedAt = DateTime.UtcNow;

            entity.ModifiedAt = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<T> Get<T>() where T : class, IEntity
    {
        return Set<T>().Where(e => !e.IsDeleted);
    }

    public IQueryable<T> GetAll<T>() where T : class, IEntity
    {
        return Set<T>();
    }

    public IQueryable<T> GetDeleted<T>() where T : class, IEntity
    {
        return Set<T>().Where(e => e.IsDeleted);
    }
    public async Task<long> Create<T>(T entity) where T : class, IEntity
    {
        await Set<T>().AddAsync(entity);
        return entity.Id;
    }
}