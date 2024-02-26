using Domain.Customars;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class Order : Entity
    {
        private Order(Guid customerId)
        {
            CustomerId = customerId;
        }
        private readonly HashSet<LineItem> _lineItems = new();
        public Guid CustomerId { get; private set; }

        public void Add(Product product)
        {
            var lineItem = LineItem.Create(Guid.NewGuid(), Id, product.Id, product.Price);
            _lineItems.Add(lineItem);
        }
        public static Order Create(Customer customer)
        {
            var order = new Order(customer.Id);
            return order;
        }
    }
    public class LineItem : Entity
    {
        private LineItem(Guid id, Guid orderId, Guid productId, Money price)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Price = price;
        }
        public static LineItem Create(Guid id, Guid orderId, Guid productId, Money price)
        {
            return new LineItem(id, orderId, productId, price);
        }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public Money Price { get; private set; }
    }
}
