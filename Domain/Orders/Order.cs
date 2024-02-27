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
        public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();
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
}
