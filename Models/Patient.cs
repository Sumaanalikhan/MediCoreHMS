using System.ComponentModel.DataAnnotations;

namespace MediCoreHMS.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Medical History")]
        public string MedicalHistory { get; set; }

        [Display(Name = "Arrival Type")]
        public string ArrivalType { get; set; } // Emergency or OPD

        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Admission> Admissions { get; set; }
    }
}