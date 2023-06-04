using AutoMapper;
using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.AutoMapper
{
    public class MapRental : Profile
    {
        public MapRental()
        {
            CreateMap<Rental, RentalViewModel>();
            CreateMap<RentalViewModel, Rental>();

        }

    }
}
