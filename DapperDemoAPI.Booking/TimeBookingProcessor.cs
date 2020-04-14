using System;

namespace DapperDemoAPI.Booking
{
    public class TimeBookingProcessor : ITimeBookingProcessor
    {
        public bool BookTime(DateTime date, decimal duration)
        {
            if (date.Date > DateTime.Today)
            {
                throw new NotImplementedException("Booking date cannot be greater than today.");
            }
            return true;

        }
    }
}
