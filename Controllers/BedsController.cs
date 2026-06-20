using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediCoreHMS.Models;

namespace MediCoreHMS.Controllers
{
    public class BedsController : Controller
    {
        private readonly AppDbContext _context;

        public BedsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Beds.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bed bed)
        {
            _context.Add(bed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var bed = await _context.Beds.FindAsync(id);
            if (bed == null) return NotFound();
            return View(bed);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Bed bed)
        {
            _context.Update(bed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var bed = await _context.Beds.FirstOrDefaultAsync(m => m.BedId == id);
            if (bed == null) return NotFound();
            return View(bed);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bed = await _context.Beds.FindAsync(id);
            if (bed != null) _context.Beds.Remove(bed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}