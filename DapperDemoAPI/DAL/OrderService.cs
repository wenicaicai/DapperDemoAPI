using ComplexClassToUseMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoAPI.DAL
{
    public class OrderService : IOrderService
    {
        public Order GenOrder()
        {
            var customer = new CustomerCx { Name = "George Costanza" };

            var order = new Order
            {
                Customera = customer
            };

            var bosco = new Product
            {
                Name = "Bosco",
                Price = 4.99m
            };

            order.AddOrderLineItem(bosco, 15);

            return order;
        }

        public OrderDto GenOrderI()
        {
            var imapper = AutoMapperConfig.GetMapper();

            var customer = new CustomerCx { Name = "George Costanza" };

            var order = new Order
            {
                Customera = customer
            };

            var bosco = new Product
            {
                Name = "Bosco",
                Price = 4.99m
            };

            order.AddOrderLineItem(bosco, 15);

            var result = imapper.Map<OrderDto>(order);

            return result;
        }
    }
}
