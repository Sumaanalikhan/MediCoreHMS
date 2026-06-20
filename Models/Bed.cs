using System.ComponentModel.DataAnnotations;

namespace MediCoreHMS.Models
{
    public class Bed
    {
        public int BedId { get; set; }

        [Required]
        [Display(Name = "Bed Number")]
        public string BedNumber { get; set; }

        [Required]
        public string Ward { get; set; } // General, ICU, Maternity, Pediatric

        [Display(Name = "Is Occupied")]
        public bool IsOccupied { get; set; } = false;

        // Navigation
        public ICollection<Admission> Admissions { get; set; }
    }
}