using System;
using System.Collections.Generic;
using System.Text;

namespace DapperDemoAPI.Booking
{
    public interface ITimeBookingProcessor
    {
        bool BookTime(DateTime date, decimal duration);
    }
}
