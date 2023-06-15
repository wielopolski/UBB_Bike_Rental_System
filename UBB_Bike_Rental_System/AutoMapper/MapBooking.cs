using AutoMapper;
using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.AutoMapper
{
    public class MapBooking : Profile
    {
        public MapBooking()
        {
            CreateMap<Booking, BookingViewModel>();
            CreateMap<Booking, DetailBookingViewModel>();
            CreateMap<DetailBookingViewModel, Booking>();
            CreateMap<BookingViewModel, Booking>();

        }

    }
}
