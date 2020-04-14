using DapperDemoAPI.Booking;
using System;
using Xunit;

namespace DapperDemoAPI.UnitTest
{
    public class TimeBookingProcessorUnitTest
    {
        [Fact]
        public void Test_Invalid_Date()
        {
            var timeBookingProcessor = new TimeBookingProcessor();
            Assert.True(timeBookingProcessor.BookTime(DateTime.Now.AddDays(1), 1));
        }
    }
}
