using CheapestHotel.Entity;
using System;
namespace CheapestHotel
{
    public interface IHotels
    {
        Hotels GetHotelInformation(string customerType, DateTime date);
    }
}