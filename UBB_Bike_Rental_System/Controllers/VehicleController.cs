using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Xml.Linq;
using UBB_Bike_Rental_System.AutoMapper;
using UBB_Bike_Rental_System.Models;
using UBB_Bike_Rental_System.Repository;

namespace UBB_Bike_Rental_System.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IMapper _mapper;
        public VehicleController(IRepository<Vehicle> vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        // GET: VehicleDetailController
        public async Task<IActionResult> Index()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
           
            try
            {
                vehicles = (await _vehicleRepository.GetAll()).Include(p => p.Type).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(_mapper.Map<List<VehicleDetailViewModel>>(vehicles));
        }

        // GET: VehicleDetailController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Vehicle vehicle;
            try
            {
                vehicle = await _vehicleRepository.GetOne(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(_mapper.Map<VehicleDetailViewModel>(vehicle));
        }

        // GET: VehicleDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleDetailViewModel vehicleView)
        {
            try
            {
                Vehicle vehicleDb = _mapper.Map<Vehicle>(vehicleView);
                
                await _vehicleRepository.Create(vehicleDb);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VehicleDetailController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
			Vehicle vehicle;
			try
			{
				vehicle = await _vehicleRepository.GetOne(id);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
			return View(_mapper.Map<VehicleDetailViewModel>(vehicle));
		}

        // POST: VehicleDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vehicle vehicle)
        {
            try
            {
                await _vehicleRepository.Update(vehicle);
            }
            catch
            {
                return View();
            }

                return RedirectToAction(nameof(Index));
        }

        // GET: VehicleDetailController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
			Vehicle vehicle;
			try
			{
				vehicle = await _vehicleRepository.GetOne(id);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return View(_mapper.Map<VehicleDetailViewModel>(vehicle));
		}

        // POST: VehicleDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Vehicle vehicle)
        {
            try
            {
                await _vehicleRepository.Delete(vehicle);
            }
            catch
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
