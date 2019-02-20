using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapestHotel.Helper
{
    public static class AddDaysToDate
    {
        public static DateTime AddDaysToCheckInDate(DateTime checkInDate, int valueToAdd)
        {
            return checkInDate.AddDays(valueToAdd);
        }
    }
}
