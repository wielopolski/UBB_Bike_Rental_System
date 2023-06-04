namespace UBB_Bike_Rental_System.Models
{
    public class VehicleDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual VehicleType Type { get; set; }
        public int VehicleTypeId { get; set; }
        public virtual Rental Rental { get; set; }
        public int RentalId { get; set; }
        public bool Electric { get; set; }
        public decimal Price { get; set; }
    }
}
