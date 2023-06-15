using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.Models
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        public string User { get; set; }

        [Display(Name = "Pojazd")]
        public int VehicleId { get; set; }
        public SelectList Vehicles { get; set; }

        [Required]
        [Display(Name = "Początek wynajmu")]
        public DateTime StartDateTime { get; set; }
        [Required]
        [Display(Name = "Planowana data oddania")]
        public DateTime EndDateTime { get; set; }
    }
}