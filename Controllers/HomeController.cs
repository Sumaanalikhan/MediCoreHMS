using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediCoreHMS.Models;

namespace MediCoreHMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // GCN = 4: Discharge stats, Emergency admissions, Monthly inflow

            var allAdmissions = await _context.Admissions
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();

            // Total patients
            ViewBag.TotalPatients = await _context.Patients.CountAsync();

            // Total doctors
            ViewBag.TotalDoctors = await _context.Doctors.CountAsync();

            // Available beds
            ViewBag.AvailableBeds = await _context.Beds.CountAsync(b => !b.IsOccupied);

            // Total beds
            ViewBag.TotalBeds = await _context.Beds.CountAsync();

            // GCN 4 — Discharge statistics
            ViewBag.TotalDischarged = allAdmissions.Count(a => a.Status == "Discharged");
            ViewBag.TotalAdmitted = allAdmissions.Count(a => a.Status == "Admitted");

            // GCN 4 — Emergency admissions
            ViewBag.EmergencyAdmissions = allAdmissions.Count(a => a.AdmissionType == "Emergency");

            // Pending discharges (admitted patients)
            ViewBag.PendingDischarges = allAdmissions.Count(a => a.Status == "Admitted");

            // GCN 4 — Monthly patient inflow (last 6 months)
            var monthlyData = allAdmissions
                .Where(a => a.AdmissionDate >= DateTime.Now.AddMonths(-6))
                .GroupBy(a => new { a.AdmissionDate.Year, a.AdmissionDate.Month })
                .Select(g => new {
                    Month = g.Key.Month + "/" + g.Key.Year,
                    Count = g.Count()
                })
                .OrderBy(x => x.Month)
                .ToList();

            ViewBag.MonthlyLabels = string.Join(",", monthlyData.Select(m => "\"" + m.Month + "\""));
            ViewBag.MonthlyValues = string.Join(",", monthlyData.Select(m => m.Count));

            // Registration number influence: seeded 39 beds (from middle digits 39,39)
            ViewBag.GCNNote = "GCN=4 | 39 beds seeded from reg digits (63972, 63931)";

            return View();
        }
    }
}