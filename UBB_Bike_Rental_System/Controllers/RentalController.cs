using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using UBB_Bike_Rental_System.AutoMapper;
using UBB_Bike_Rental_System.Models;
using UBB_Bike_Rental_System.Repository;

namespace UBB_Bike_Rental_System.Controllers
{
	public class RentalController : Controller
	{

		private readonly IRepository<Rental> _rentalRepository;
		private readonly IMapper _mapper;
		public RentalController(IRepository<Rental> rentalRepository, IMapper mapper)
		{
			_rentalRepository = rentalRepository;
			_mapper = mapper;
		}

		// GET: RentalDetailController
		public async Task<IActionResult> Index()
		{
			List<Rental> Rentals = new List<Rental>();

			try
			{
				Rentals = (await _rentalRepository.GetAll()).ToList();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
			return View(_mapper.Map<List<RentalViewModel>>(Rentals));
		}

		// GET: RentalDetailController/Details/5
		public async Task<IActionResult> Details(int id)
		{
			Rental Rentals;
			try
			{
				Rentals = await _rentalRepository.GetOne(id);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
			return View(Rentals);
		}

		// GET: RentalDetailController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: RentalDetailController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(RentalViewModel RentalView)
		{
			try
			{
				Rental RentalDb = _mapper.Map<Rental>(RentalView);

				await _rentalRepository.Create(RentalDb);
			}
			catch
			{
				return View();
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: RentalDetailController/Edit/5
		public ActionResult Edit(int id)
		{
			return View(/*Rentals.FirstOrDefault(i => i.Id == id)*/);
		}

		// POST: RentalDetailController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Rental Rental)
		{
			try
			{
				await _rentalRepository.Update(Rental);
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
			return View(await _rentalRepository.GetOne(id));
		}

		// POST: RentalDetailController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id, Rental Rental)
		{
			try
			{
				await _rentalRepository.Delete(Rental);
			}
			catch
			{
				return View();
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
