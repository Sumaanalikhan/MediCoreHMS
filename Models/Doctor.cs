using System.ComponentModel.DataAnnotations;

namespace MediCoreHMS.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [Display(Name = "Assigned Ward")]
        public string AssignedWard { get; set; } // General, ICU, Maternity, Pediatric

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Consultation Schedule")]
        public string ConsultationSchedule { get; set; }

        // Navigation
        public ICollection<Admission> Admissions { get; set; }
    }
}