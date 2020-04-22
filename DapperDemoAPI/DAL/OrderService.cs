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

        public OrderDto GenOrderII()
        {
            var customer = new CustomerCx { Name = "Bob" };

            var order = new Order { Customera = customer, Total = 15.8m };

            var imapper = AutoMapperConfig.GetMapper();

            var orderDto = imapper.Map<OrderDto>(order);

            orderDto.CustomeraName = "Joe";

            imapper.Map(orderDto, order);

            return orderDto;
        }

        public CalendarEventForm GenIV()
        {
            var calentdatEnvet = new CalendarEvent
            {
                Date = new DateTime(2020, 04, 22, 20, 15, 0),
                Title = "Company Holiday Party"
            };

            var imapper = AutoMapperConfig.GetMapper();

            CalendarEventForm calendarEventForm = imapper.Map<CalendarEvent, CalendarEventForm>(calentdatEnvet);

            return calendarEventForm;
        }
    }
}
