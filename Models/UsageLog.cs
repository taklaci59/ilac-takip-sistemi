using System.ComponentModel.DataAnnotations;

namespace ilactakipsistem.Models
{
    public class UsageLog
    {
        public int Id { get; set; }

        [Required]
        public int MedicineId { get; set; }
        public virtual Medicine? Medicine { get; set; }

        [Required]
        [Display(Name = "Kullanım Tarihi")]
        public DateTime DateTaken { get; set; }

        [Required]
        [Display(Name = "Durum")]
        public bool IsTaken { get; set; } // true: Alındı, false: Kaçırıldı
    }
}
