using ilactakipsistem.Data;
using ilactakipsistem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ilactakipsistem.Controllers
{
    public class DosageController : BaseController
    {
        public DosageController(AppDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> Index()
        {
            var schedules = await _context.DosageSchedules.Include(d => d.Medicine).ToListAsync();
            return View(schedules);
        }

        public IActionResult Create()
        {
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedicineId,ReminderTime,DosageAmount")] DosageSchedule dosageSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dosageSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedicineId"] = new SelectList(_context.Medicines, "Id", "Name", dosageSchedule.MedicineId);
            return View(dosageSchedule);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var dosageSchedule = await _context.DosageSchedules.Include(d => d.Medicine).FirstOrDefaultAsync(m => m.Id == id);
            if (dosageSchedule == null) return NotFound();
            return View(dosageSchedule);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dosageSchedule = await _context.DosageSchedules.FindAsync(id);
            if (dosageSchedule != null)
            {
                _context.DosageSchedules.Remove(dosageSchedule);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
