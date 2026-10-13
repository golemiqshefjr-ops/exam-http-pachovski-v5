using System.ComponentModel.DataAnnotations;

namespace ExamMvc.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето „Име“ е задължително.")]
        [StringLength(200)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето „Град“ е задължително.")]
        [StringLength(100)]
        [Display(Name = "Град")]
        public string City { get; set; }

        [Required(ErrorMessage = "Полето „Вид“ е задължително.")]
        [StringLength(50)]
        [Display(Name = "Вид")]
        public string Type { get; set; }

        [Range(1, 2000, ErrorMessage = "Стаи: стойност между 1 и 2000.")]
        [Display(Name = "Стаи")]
        public int Rooms { get; set; }

        [Range(0.0, 5000.0, ErrorMessage = "Цена на нощувка (лв.): стойност между 0 и 5000.")]
        [Display(Name = "Цена на нощувка (лв.)")]
        public decimal PricePerNight { get; set; }
    }
}
