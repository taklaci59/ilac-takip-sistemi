using System.ComponentModel.DataAnnotations;

namespace ilactakipsistem.Models
{
    public enum DosageFrequency
    {
        [Display(Name = "Günde X Kez")]
        Daily,
        [Display(Name = "Haftalık")]
        Weekly,
        [Display(Name = "Belirli Aralıklarla")]
        Interval
    }

    public class DosageSchedule
    {
        public int Id { get; set; }

        [Required]
        public int MedicineId { get; set; }
        public virtual Medicine? Medicine { get; set; }

        [Required]
        public DosageFrequency Frequency { get; set; } = DosageFrequency.Daily;

        [Display(Name = "Günde Kaç Doz? / Haftanın Hangi Günü?")]
        public string? FrequencyValue { get; set; } // e.g. "2" for daily, "Monday" for weekly

        [Required(ErrorMessage = "Hatırlatma saati zorunludur.")]
        [Display(Name = "Hatırlatma Saati")]
        public TimeSpan ReminderTime { get; set; }

        [Required(ErrorMessage = "Dozaj miktarı zorunludur.")]
        [Display(Name = "Doz Miktarı")]
        public double DosageAmount { get; set; } = 1.0;
    }
}
