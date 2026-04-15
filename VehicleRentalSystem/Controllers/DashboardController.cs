using Microsoft.AspNetCore.Mvc;
using VehicleRentalSystem.Data;
using Microsoft.AspNetCore.Authorization;


namespace VehicleRentalSystem.Controllers
{
     [Authorize] 
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalVehicles = _context.Vehicles.Count();
            var totalCustomers = _context.Customers.Count();
            var totalReservations = _context.Reservations.Count();
            var totalRevenue = _context.Reservations.Sum(r => r.TotalPrice);

            ViewBag.Vehicles = totalVehicles;
            ViewBag.Customers = totalCustomers;
            ViewBag.Reservations = totalReservations;
            ViewBag.Revenue = totalRevenue;

            return View();
        }
    }
}