using AutoMapper;
using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.AutoMapper
{
    public class MapVehicleDetialViewModelToVehicle : Profile
    {
        public MapVehicleDetialViewModelToVehicle()
        {
            CreateMap<VehicleDetailViewModel,Vehicle>();
        }

    }
}
