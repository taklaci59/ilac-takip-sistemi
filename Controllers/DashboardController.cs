using ilactakipsistem.Data;
using ilactakipsistem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ilactakipsistem.Controllers
{
    public class DashboardController : BaseController
    {
        public DashboardController(AppDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> Index()
        {
            var hasCookie = Request.Cookies.ContainsKey("ATS_OnboardingComplete");
            var profile = await _context.UserProfiles.FirstOrDefaultAsync();
            
            if (!hasCookie || profile == null || !profile.IsOnboardingComplete)
            {
                return RedirectToAction("Onboarding", "PersonalAssistant");
            }

            var today = DateTime.Today;
            var now = DateTime.Now;
            var currentTime = now.TimeOfDay;

            var allSchedules = await _context.DosageSchedules.Include(d => d.Medicine).ToListAsync();
            var todayLogs = await _context.UsageLogs.Where(l => l.DateTaken.Date == today).ToListAsync();

            // 1 SAAT KURALI KONTROLÜ (Missed Dose Logic)
            bool saveNeeded = false;
            foreach (var schedule in allSchedules)
            {
                if (currentTime > schedule.ReminderTime.Add(TimeSpan.FromHours(1)))
                {
                    var expectedTime = today.Add(schedule.ReminderTime);
                    // Check if there is any log within 2 hours of this expected time for this medicine
                    var hasLog = todayLogs.Any(l => l.MedicineId == schedule.MedicineId && 
                                                    Math.Abs((l.DateTaken - expectedTime).TotalHours) <= 2);

                    if (!hasLog)
                    {
                        var missedLog = new UsageLog
                        {
                            MedicineId = schedule.MedicineId,
                            DateTaken = expectedTime, // Set date taken to when it was supposed to be taken
                            IsTaken = false
                        };
                        _context.UsageLogs.Add(missedLog);
                        todayLogs.Add(missedLog);
                        saveNeeded = true;
                    }
                }
            }

            if (saveNeeded)
            {
                await _context.SaveChangesAsync();
            }

            var todayPlan = new List<dynamic>();

            foreach(var schedule in allSchedules.OrderBy(s => s.ReminderTime))
            {
                var expectedTime = today.Add(schedule.ReminderTime);
                var log = todayLogs.FirstOrDefault(l => l.MedicineId == schedule.MedicineId && 
                                                        Math.Abs((l.DateTaken - expectedTime).TotalHours) <= 2);
                
                string status = "Bekliyor"; // Pending
                if (log != null)
                {
                    status = log.IsTaken ? "Alındı" : "Kaçırıldı";
                }

                todayPlan.Add(new {
                    MedicineName = schedule.Medicine?.Name,
                    MedicineId = schedule.MedicineId,
                    TimeStr = schedule.ReminderTime.ToString(@"hh\:mm"),
                    TimeObj = schedule.ReminderTime,
                    Status = status
                });
            }

            ViewBag.UserName = profile.UserName;
            ViewBag.TodayPlan = todayPlan;
            ViewBag.SchedulesJson = System.Text.Json.JsonSerializer.Serialize(todayPlan);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RecordDose(int medicineId)
        {
            var medicine = await _context.Medicines.FindAsync(medicineId);
            
            if (medicine != null)
            {
                var log = new UsageLog
                {
                    MedicineId = medicine.Id,
                    DateTaken = DateTime.Now,
                    IsTaken = true
                };
                
                _context.UsageLogs.Add(log);
                await _context.SaveChangesAsync();
                
                return Json(new { success = true, medName = medicine.Name });
            }
            
            return Json(new { success = false, message = "Aktif bir ilaç bulunamadı." });
        }

        public async Task<IActionResult> History()
        {
            var logs = await _context.UsageLogs
                .Include(l => l.Medicine)
                .OrderByDescending(l => l.DateTaken)
                .ToListAsync();
            return View(logs);
        }
    }
}
