using System.ComponentModel.DataAnnotations.Schema;

namespace UBB_Bike_Rental_System.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string User { get; set; }

        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

    }
}
