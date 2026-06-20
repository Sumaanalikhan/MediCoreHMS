using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediCoreHMS.Models;

namespace MediCoreHMS.Controllers
{
    public class AdmissionsController : Controller
    {
        private readonly AppDbContext _context;

        public AdmissionsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var admissions = _context.Admissions
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Bed);
            return View(await admissions.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var admission = await _context.Admissions
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Bed)
                .FirstOrDefaultAsync(m => m.AdmissionId == id);
            if (admission == null) return NotFound();
            return View(admission);
        }

        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FullName");
            ViewData["DoctorId"] = new SelectList(_context.Doctors.Where(d => d.IsAvailable), "DoctorId", "FullName");
            ViewData["BedId"] = new SelectList(_context.Beds.Where(b => !b.IsOccupied), "BedId", "BedNumber");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Admission admission)
        {
            var bed = await _context.Beds.FindAsync(admission.BedId);
            admission.AdmissionDate = DateTime.Now;
            admission.Status = "Admitted";
            _context.Add(admission);
            if (bed != null) bed.IsOccupied = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Discharge action
        public async Task<IActionResult> Discharge(int? id)
        {
            if (id == null) return NotFound();
            var admission = await _context.Admissions
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Bed)
                .FirstOrDefaultAsync(m => m.AdmissionId == id);
            if (admission == null) return NotFound();
            return View(admission);
        }

        [HttpPost, ActionName("Discharge")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DischargeConfirmed(int id)
        {
            var admission = await _context.Admissions.Include(a => a.Bed).FirstOrDefaultAsync(a => a.AdmissionId == id);
            if (admission != null)
            {
                admission.DischargeDate = DateTime.Now;
                admission.Status = "Discharged";
                if (admission.Bed != null) admission.Bed.IsOccupied = false;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var admission = await _context.Admissions
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Bed)
                .FirstOrDefaultAsync(m => m.AdmissionId == id);
            if (admission == null) return NotFound();
            return View(admission);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admission = await _context.Admissions.Include(a => a.Bed).FirstOrDefaultAsync(a => a.AdmissionId == id);
            if (admission != null)
            {
                if (admission.Bed != null) admission.Bed.IsOccupied = false;
                _context.Admissions.Remove(admission);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}