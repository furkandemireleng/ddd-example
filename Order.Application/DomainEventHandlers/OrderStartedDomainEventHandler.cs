using MediatR;
using Order.Application.Repository;
using Order.Domain.AggregateModels.BuyerModels;
using Order.Domain.Events;

namespace Order.Application.DomainEventHandlers;

internal class OrderStartedDomainEventHandler:INotificationHandler<OrderStartedDomainEvent>

    
    private readonly IBuyerRepository buyerRepository;


    public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
    {
        this.buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
    }

    public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
    {
        if (notification.Order.BuyerId == 0)
        {

            var buyer = new Buyer(notification.BuyerFirstName, notification.BuyerLastName);
            
            //buyerRepository.Add(buyer);
            
        }
            
    }   
}