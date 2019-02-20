using System;
using CheapestHotel;
using CheapestHotel.Constants;
using CheapestHotel.Entity;
using CheapestHotel.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheapestHotelTests
{
    [TestClass]
    public class CheapestHotelTest
    {

        [TestMethod]
        public void GetDayFromDateTest()
        {
            var result = ConvertDateToDay.GetDayFromDate(DateTime.Now);
            Assert.AreEqual(DayOfTheWeek.weekday.ToString(), result);
        }

        [TestMethod]
        public void GetAllHotelInfoTest()
        {
            Hotels hotels = new Hotels();
            HotelLakewood hotelLakewood = new HotelLakewood("regular", "reward", 100, 100, 100, 100);
            var result = hotelLakewood.GetHotelInformation("reward", DateTime.Now);
            Assert.IsTrue(result.GetType().Equals(hotels.GetType()));


        }
    }  
}
