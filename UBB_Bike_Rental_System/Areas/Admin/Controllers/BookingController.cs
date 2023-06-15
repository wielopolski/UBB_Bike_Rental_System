using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using UBB_Bike_Rental_System.AutoMapper;
using UBB_Bike_Rental_System.Models;
using UBB_Bike_Rental_System.Repository;

namespace UBB_Bike_Rental_System.Areas.Admin;

    [Area("Admin")]
    public class BookingController : Controller
{

	private readonly IRepository<Booking> _bookingRepository;
	private readonly IRepository<Rental> _rentalRepository;
    private readonly IRepository<Vehicle> _vehicleRepository;
    private readonly IMapper _mapper;
	public BookingController(IRepository<Rental> rentalRepository, IRepository<Booking> bookingRepository, IRepository<Vehicle> vehicleRepository, IMapper mapper)
	{
		_bookingRepository = bookingRepository;
		_rentalRepository = rentalRepository;
		_vehicleRepository = vehicleRepository;
		_mapper = mapper;
	}

	// GET: RentalDetailController
	public async Task<IActionResult> Index()
	{
		List<Booking> bookings = new List<Booking>();

		try
		{
            bookings = (await _bookingRepository.GetAll()).ToList();
		}
		catch (Exception e)
		{
			return BadRequest(e.Message);
		}
		return View(_mapper.Map<List<DetailBookingViewModel>>(bookings));
	}

	// GET: RentalDetailController/Details/5
	public async Task<IActionResult> Details(int id)
	{
		Booking booking;
            List<Booking> vehicles = new List<Booking>();
            try
		{
                
            booking = await _bookingRepository.GetOne(id);
			BookingViewModel bookingViewModel = _mapper.Map<BookingViewModel>(booking);
                return View(bookingViewModel);
            }
		catch (Exception e)
		{
			return BadRequest(e.Message);
		}
	}

	// GET: RentalDetailController/Create
	public async Task<ActionResult> Create()
	{
        BookingViewModel booking = new BookingViewModel();
        var vehicleList = (await _vehicleRepository.GetAll()).ToList();
        booking.Vehicles = new SelectList(vehicleList, "Id", "Name");

        return View(booking);

	}

	// POST: RentalDetailController/Create
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(RentalViewModel rentalView)
	{
		try
		{
			Rental rentalDb = _mapper.Map<Rental>(rentalView);

			await _rentalRepository.Create(rentalDb);
		}
		catch
		{
			return View(rentalView);
		}
		return RedirectToAction(nameof(Index));
	}

	// GET: RentalDetailController/Edit/5
	public async Task<ActionResult> Edit(int id)
	{
            Rental rental;
            try
            {
                rental = await _rentalRepository.GetOne(id);
                RentalViewModel rentalViewModel = _mapper.Map<RentalViewModel>(rental);
                return View(rentalViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

	// POST: RentalDetailController/Edit/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, Rental rental)
	{
		try
		{
			await _rentalRepository.Update(rental);
		}
		catch
		{
			return View();
		}

		return RedirectToAction(nameof(Index));
	}

	// GET: RentalDetailController/Delete/5
	public async Task<IActionResult> Delete(int id)
	{
            Rental rental;
            try
            {
                rental = await _rentalRepository.GetOne(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return View(_mapper.Map<RentalViewModel>(rental));
        }

	// POST: RentalDetailController/Delete/5
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Delete(int id, Rental rental)
	{
		try
		{
			await _rentalRepository.Delete(rental);
		}
		catch
		{
			return View();
		}
		return RedirectToAction(nameof(Index));
	}
}
