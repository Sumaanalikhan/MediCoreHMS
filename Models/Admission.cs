using System.ComponentModel.DataAnnotations;

namespace MediCoreHMS.Models
{
    public class Admission
    {
        public int AdmissionId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int BedId { get; set; }

        [Required]
        public string Ward { get; set; }

        [Display(Name = "Admission Date")]
        public DateTime AdmissionDate { get; set; } = DateTime.Now;

        [Display(Name = "Discharge Date")]
        public DateTime? DischargeDate { get; set; }

        [Display(Name = "Admission Type")]
        public string AdmissionType { get; set; } // Emergency or OPD

        public string Status { get; set; } = "Admitted"; // Admitted or Discharged

        [Display(Name = "Treatment Notes")]
        public string TreatmentNotes { get; set; }

        // Navigation
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Bed Bed { get; set; }
    }
}