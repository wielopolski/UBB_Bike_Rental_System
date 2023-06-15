using FluentValidation;
using UBB_Bike_Rental_System.Models;

namespace UBB_Bike_Rental_System.Validators
{
    public class ReservationValidator : AbstractValidator<Booking>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.EndDateTime).GreaterThan(x => x.StartDateTime);
        }
    }
}
