using System.ComponentModel.DataAnnotations;

namespace VehicleRentalSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
