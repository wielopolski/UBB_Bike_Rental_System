using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace UBB_Bike_Rental_System.Models
{
    public class VehicleEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Electric { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Kategoria")]
        public int VehicleTypeId { get; set; }
        public SelectList VehicleTypes { get; set; }

        [Display(Name = "Wypozyczalnia")]
        public int RentalId { get; set; }
        public SelectList Rentals { get; set; }
    }
}
