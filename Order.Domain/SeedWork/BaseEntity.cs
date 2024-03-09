using MediatR;

namespace Order.Domain.SeedWork;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public ICollection<INotification> DomainEvents { get; set; }

    public void AddDomainEvents(INotification notification)
    {
        DomainEvents = new List<INotification>();
        DomainEvents.Add(notification);
    }
}