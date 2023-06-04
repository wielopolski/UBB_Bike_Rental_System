using AutoMapper;
using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.AutoMapper
{
    public class MapVehicle : Profile
    {
        public MapVehicle()
        {
            CreateMap<Vehicle, VehicleDetailViewModel>();
            CreateMap<Vehicle, VehicleEditViewModel>();
            CreateMap<VehicleDetailViewModel, Vehicle>();
            CreateMap<VehicleEditViewModel, Vehicle>();

        }

    }
}
