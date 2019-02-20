using CheapestHotel.Constants;
using System;
namespace CheapestHotel.Helper
{
    public static class ConvertDateToDay
    {
        /// <summary>
        /// Converts date to the day of the week
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetDayFromDate(DateTime date)
        {
            try
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    return DayOfTheWeek.weekend.ToString();
                }
                else
                {
                    return DayOfTheWeek.weekday.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public static class AddDaysToDate
    {
        /// <summary>
        /// Add value to the day to increment it
        /// </summary>
        /// <param name="checkInDate"></param>
        /// <param name="valueToAdd"></param>
        /// <returns></returns>
        public static DateTime AddDaysToCheckInDate(DateTime checkInDate, int valueToAdd)
        {
            try
            {
                return checkInDate.AddDays(valueToAdd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
