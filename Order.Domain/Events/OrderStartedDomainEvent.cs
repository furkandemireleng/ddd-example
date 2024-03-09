using MediatR;

namespace Order.Domain.Events;

public class OrderStartedDomainEvent : INotification
{
    public string BuyerFirstName { get; set; }

    public string BuyerLastName { get; set; }
    public AggregateModels.OrderModels.Order Order { get; set; }

    public OrderStartedDomainEvent(string buyerFirstName, string buyerLastName, AggregateModels.OrderModels.Order order)
    {
        BuyerFirstName = buyerFirstName ?? throw new ArgumentNullException(nameof(buyerFirstName));
        BuyerLastName = buyerLastName ?? throw new ArgumentNullException(nameof(buyerLastName));
        Order = order ?? throw new ArgumentNullException(nameof(order));
    }
}