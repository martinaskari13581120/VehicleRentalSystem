using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleRentalSystem.Data;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = _context.Reservations
                .Include(r => r.Vehicle)
                .Include(r => r.Customer);

            return View(await data.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Vehicles = new SelectList(_context.Vehicles, "Id", "Model");
            ViewBag.Customers = new SelectList(_context.Customers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            var vehicle = await _context.Vehicles.FindAsync(reservation.VehicleId);

            var days = (reservation.EndDate - reservation.StartDate).Days;
            reservation.TotalPrice = days * vehicle.PricePerDay;

            _context.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}