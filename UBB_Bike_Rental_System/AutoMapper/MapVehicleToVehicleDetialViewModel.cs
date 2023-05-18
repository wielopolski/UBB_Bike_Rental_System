using AutoMapper;
using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.AutoMapper
{
    public class MapVehicleToVehicleDetialViewModel : Profile
    {
        public MapVehicleToVehicleDetialViewModel()
        {
            CreateMap<Vehicle, VehicleDetailViewModel>();
            CreateMap<Vehicle, VehicleEditViewModel>();

        }

    }
}
