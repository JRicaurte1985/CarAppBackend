
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarAppBackend.DTOs
{
    public class CarDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        [RegularExpression("[a-z0-9]{24}",
         ErrorMessage = "CarID must be 24 characters, alphanumeric.")]
        public string CarId { get; set; } = null!;
        [Required]
        public string Make { get; set; } = null!;
        [Required]
        public int Year { get; set; }
        [Required]
        public string Color { get; set; } = null!;
        [Required]
        public int Price { get; set; }
        [Required]
        public bool HasSunroof { get; set; }
        [Required]
        public bool IsFourWheelDrive { get; set; }
        [Required]
        public bool HasLowMiles { get; set; }
        [Required]
        public bool HasPowerWindows { get; set; }
        [Required]
        public bool HasNavigation { get; set; }
        [Required]
        public bool HasHeatedSeats { get; set; }
    }
}
