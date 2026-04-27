using System.ComponentModel.DataAnnotations;

namespace ilactakipsistem.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İlaç adı zorunludur.")]
        [Display(Name = "İlaç Adı")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Display(Name = "Mevcut Stok")]
        public int StockQuantity { get; set; }

        [Display(Name = "Kritik Stok Seviyesi")]
        public int CriticalStockLevel { get; set; } = 5;

        [Display(Name = "Birim")]
        public string Unit { get; set; } = "Adet";

        public virtual ICollection<DosageSchedule> DosageSchedules { get; set; } = new List<DosageSchedule>();
        public virtual ICollection<UsageLog> UsageLogs { get; set; } = new List<UsageLog>();
    }
}
