using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleRentalSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
