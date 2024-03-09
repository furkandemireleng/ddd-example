using Order.Domain.Events;
using Order.Domain.SeedWork;

namespace Order.Domain.AggregateModels.OrderModels;

public class Order : BaseEntity, IAggregateRoot
{
    public DateTime OrderDate { get; private set; }

    public string Description { get; private set; }

    public string OrderStatus { get; private set; }

    public int BuyerId { get; private set; }

    public Address Addresses { get; private set; }

    public ICollection<OrderItem> OrderItems { get; private set; }


    public Order(DateTime orderDate,int buyerId, string description, string orderStatus, Address addresses, ICollection<OrderItem> orderItems)
    {
        if (orderDate < DateTime.Now)
        {
            throw new Exception("Order Date can not be greater than today");
        }

        if (addresses.City == "")
        {
            throw new Exception("City cant blank");
        }

        OrderDate = orderDate;
        Description = description;
        BuyerId = buyerId;
        OrderStatus = orderStatus;
        Addresses = addresses;
        OrderItems = orderItems;
        
        
        AddDomainEvents(new OrderStartedDomainEvent("","",this));
    }

    public void AddOrderItem(int quantity, decimal price, int productId)
    {
        OrderItem item = new(quantity, price, productId);
        OrderItems.Add(item);
    }
}