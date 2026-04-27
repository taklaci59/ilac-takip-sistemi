using ilactakipsistem.Data;
using ilactakipsistem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ilactakipsistem.Controllers
{
    public class PersonalAssistantController : Controller
    {
        private readonly AppDbContext _context;

        public PersonalAssistantController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Onboarding()
        {
            var hasCookie = Request.Cookies.ContainsKey("ATS_OnboardingComplete");
            var profile = await _context.UserProfiles.FirstOrDefaultAsync();
            
            if (hasCookie && profile != null && profile.IsOnboardingComplete)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOnboarding(string userName, List<MedicineWizardModel> medicines)
        {
            var profile = await _context.UserProfiles.FirstOrDefaultAsync() ?? new UserProfile();
            profile.UserName = userName;
            profile.IsOnboardingComplete = true;

            if (profile.Id == 0) _context.UserProfiles.Add(profile);
            else _context.UserProfiles.Update(profile);

            // Cookie set
            Response.Cookies.Append("ATS_OnboardingComplete", "true", new CookieOptions 
            { 
                Expires = DateTime.Now.AddYears(1), 
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            // Logic to save medicines from the wizard
            if (medicines != null)
            {
                foreach (var med in medicines)
                {
                    var medicine = new Medicine
                    {
                        Name = med.Name,
                        StockQuantity = med.Stock,
                        Unit = med.Unit ?? "Adet",
                        Description = med.Description
                    };
                    _context.Medicines.Add(medicine);
                    await _context.SaveChangesAsync(); // Need ID for schedule

                    if (med.Dosages != null)
                    {
                        foreach (var dos in med.Dosages)
                        {
                            _context.DosageSchedules.Add(new DosageSchedule
                            {
                                MedicineId = medicine.Id,
                                Frequency = dos.Frequency,
                                ReminderTime = dos.Time,
                                DosageAmount = 1
                            });
                        }
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Json(new { success = true, redirectUrl = Url.Action("Index", "Dashboard") });
        }
    }

    public class MedicineWizardModel
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public string? Unit { get; set; }
        public string? Description { get; set; }
        public List<DosageWizardModel>? Dosages { get; set; }
    }

    public class DosageWizardModel
    {
        public DosageFrequency Frequency { get; set; }
        public TimeSpan Time { get; set; }
    }
}
