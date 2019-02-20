using CheapestHotel.Constants;
using CheapestHotel.Entity;
using CheapestHotel.Helper;
using System;
using System.Collections.Generic;

namespace CheapestHotel
{
    class HotelBridgewood : IHotels
    {
        #region Global Declarations
        Dictionary<string, double> PriceOnADayForRegular = new Dictionary<string, double>();
        Dictionary<string, double> PriceOnADayForReward = new Dictionary<string, double>();
        Dictionary<string, Dictionary<string, double>> CustomerWithPrice = new Dictionary<string, Dictionary<string, double>>();

        #endregion

        #region Private Variables
        private const string _nameOfTheHotel = "bridgewood";
        #endregion

        #region Constructor
        public HotelBridgewood(string customerTypeRegular, string customerTypeReward, double priceOnAWeekDayforRegular, double priceOnAWeekendForRegular, double priceOnAWeekDayforReward, double priceOnAWeekendForReward)
        {
            PriceOnADayForRegular.Add(DayOfTheWeek.weekday.ToString(), priceOnAWeekDayforRegular);
            PriceOnADayForRegular.Add(DayOfTheWeek.weekend.ToString(), priceOnAWeekendForRegular);


            PriceOnADayForReward.Add(DayOfTheWeek.weekday.ToString(), priceOnAWeekDayforReward);
            PriceOnADayForReward.Add(DayOfTheWeek.weekend.ToString(), priceOnAWeekendForReward);

            CustomerWithPrice.Add(customerTypeRegular, PriceOnADayForRegular);
            CustomerWithPrice.Add(customerTypeReward, PriceOnADayForReward);

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all hotel related Information
        /// </summary>
        /// <param name="customerType"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public Hotels GetHotelInformation(string customerType, DateTime date)
        {
            try
            {
                Hotels hotels = new Hotels
                {
                    NameOfTheHotel = _nameOfTheHotel,
                    RatingOfTheHotel = Convert.ToInt32(RatingOfHotels.bridgewoord),
                    PriceOfTheHotel = GetPriceOfHotel(customerType, date)

                };
                return hotels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods
        private double GetPriceOfHotel(string customerType, DateTime date)
        {
            try
            {
                double hotelPrice = 0;
                var isCustomerTypePresentPresent = CustomerWithPrice.TryGetValue(customerType, out Dictionary<string, double> price);
                if (isCustomerTypePresentPresent)
                {
                    var isPricePresent = price.TryGetValue(ConvertDateToDay.GetDayFromDate(date), out double priceOfHotel);
                    if (isPricePresent)
                    {
                        hotelPrice = priceOfHotel;
                    }

                    return hotelPrice;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

    }
}



