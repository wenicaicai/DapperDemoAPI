using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace ComplexClassToUseMapper
{
    public class Order
    {
        private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();

        public decimal Total { get; set; }
        public CustomerCx Customera { get; set; }

        public OrderLineItem[] GetOrderLineItems(Product product, int quantity)
        {
            return _orderLineItems.ToArray();
        }

        public void AddOrderLineItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }

        public decimal GetTotal()
        {
            return _orderLineItems.Sum(li => li.GetTotal());
        }
    }

    public class Product
    {
        public decimal Price { get; set; }

        public string Name { get; set; }
    }

    public class OrderLineItem
    {
        public OrderLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }

    }

    public class CustomerCx
    {
        public string Name { get; set; }
    }
}
