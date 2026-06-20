using Microsoft.EntityFrameworkCore;

namespace MediCoreHMS.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Admission> Admissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Doctors (schedule influenced by reg digits 63, 63)
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, FullName = "Dr. Ahmed Raza", Specialization = "General Medicine", AssignedWard = "General", IsAvailable = true, ConsultationSchedule = "9AM-3PM" },
                new Doctor { DoctorId = 2, FullName = "Dr. Sara Khan", Specialization = "Intensive Care", AssignedWard = "ICU", IsAvailable = true, ConsultationSchedule = "8AM-2PM" },
                new Doctor { DoctorId = 3, FullName = "Dr. Fatima Malik", Specialization = "Gynecology", AssignedWard = "Maternity", IsAvailable = true, ConsultationSchedule = "10AM-4PM" },
                new Doctor { DoctorId = 4, FullName = "Dr. Usman Ali", Specialization = "Pediatrics", AssignedWard = "Pediatric", IsAvailable = false, ConsultationSchedule = "9AM-1PM" },
                new Doctor { DoctorId = 5, FullName = "Dr. Bilal Qureshi", Specialization = "General Medicine", AssignedWard = "General", IsAvailable = true, ConsultationSchedule = "2PM-8PM" }
            );

            // Seed Beds (39 beds based on middle digits of reg numbers)
            var beds = new List<Bed>();
            int bedId = 1;
            // General: 13 beds, ICU: 8 beds, Maternity: 10 beds, Pediatric: 8 beds = 39 total
            for (int i = 1; i <= 13; i++)
                beds.Add(new Bed { BedId = bedId++, BedNumber = "G-" + i, Ward = "General", IsOccupied = false });
            for (int i = 1; i <= 8; i++)
                beds.Add(new Bed { BedId = bedId++, BedNumber = "ICU-" + i, Ward = "ICU", IsOccupied = false });
            for (int i = 1; i <= 10; i++)
                beds.Add(new Bed { BedId = bedId++, BedNumber = "M-" + i, Ward = "Maternity", IsOccupied = false });
            for (int i = 1; i <= 8; i++)
                beds.Add(new Bed { BedId = bedId++, BedNumber = "P-" + i, Ward = "Pediatric", IsOccupied = false });

            modelBuilder.Entity<Bed>().HasData(beds);
        }
    }
}