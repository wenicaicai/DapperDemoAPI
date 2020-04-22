using ComplexClassToUseMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemoAPI.DAL
{
    public interface IOrderService
    {
        Order GenOrder();

        OrderDto GenOrderI();

        OrderDto GenOrderII();
    }
}
