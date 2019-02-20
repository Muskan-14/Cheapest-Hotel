using CheapestHotel.Entity;
using CheapestHotel.Helper;
using System;
using System.Collections.Generic;

namespace CheapestHotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HotelLakewood hotelLakewood = new HotelLakewood("REGULAR", "REWARD", 110, 100, 100, 90);
            HotelRidgewood hotelRidgewood = new HotelRidgewood("REGULAR", "REWARD", 120, 110, 105, 95);
            HotelBridgewood hotelBridgewood = new HotelBridgewood("REGULAR", "REWARD", 130, 90, 90, 80);
            List<IHotels> listOfhotels = new List<IHotels>
            {
                hotelLakewood,
                hotelRidgewood,
                hotelBridgewood
            };
            int numerOfTestCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numerOfTestCases; i++)
            {
                Hotels hotelInfo = new Hotels();
                Hotels cheapestPrice = new Hotels
                {
                    PriceOfTheHotel = Int32.MaxValue
                };
                double sumOfPriceOfAllDays = 0;

                var inputs = Console.ReadLine().Split(' ');
                string typeOfCustomer = inputs[0];

                foreach (var hotel in listOfhotels)
                {
                    for (int j = 1; j < inputs.Length; j++)
                    {
                        //Get all information related to the hotel
                        hotelInfo = hotel.GetHotelInformation(typeOfCustomer, Convert.ToDateTime(inputs[j]));
                        sumOfPriceOfAllDays += hotelInfo.PriceOfTheHotel;
                        
                    }
                    if (sumOfPriceOfAllDays < cheapestPrice.PriceOfTheHotel)
                    {
                        cheapestPrice.PriceOfTheHotel = sumOfPriceOfAllDays;
                        cheapestPrice.NameOfTheHotel = hotelInfo.NameOfTheHotel;
                        cheapestPrice.RatingOfTheHotel = hotelInfo.RatingOfTheHotel;

                    }
                    else if (sumOfPriceOfAllDays == cheapestPrice.PriceOfTheHotel)
                    {
                        //check for rating if price is same for hotels
                        cheapestPrice.PriceOfTheHotel = sumOfPriceOfAllDays;
                        if(cheapestPrice.RatingOfTheHotel > hotelInfo.RatingOfTheHotel)
                        {
                            cheapestPrice.NameOfTheHotel = cheapestPrice.NameOfTheHotel;
                        }
                        else
                            cheapestPrice.NameOfTheHotel = hotelInfo.NameOfTheHotel;
                    }

                    sumOfPriceOfAllDays = 0;
                    
                }
                Console.WriteLine("{0} ${1}", cheapestPrice.NameOfTheHotel, cheapestPrice.PriceOfTheHotel);



            }
            Console.ReadLine();
        }

        #region Private Methods
        /// <summary>
        /// Takes every hotel and compares the price by checkin and checkout date
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="checkInDate"></param>
        /// <param name="checkOutDate"></param>
        /// <param name="customerType"></param>
        /// <returns></returns>
        private static double GetTotalPrice(IHotels hotel, DateTime checkInDate, DateTime checkOutDate, string customerType)
        {
           
            try
            {
                double totalPrice = 0;
                if (checkInDate > checkOutDate)
                {
                    return 0;
                }
                else
                {
                    for (var temp = checkInDate; temp < checkOutDate; AddDaysToDate.AddDaysToCheckInDate(temp, 1))
                    {
                        var result = hotel.GetHotelInformation(customerType, temp);
                        totalPrice = result.PriceOfTheHotel;
                    }
                    return totalPrice;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
