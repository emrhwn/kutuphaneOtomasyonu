using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp1.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; }

        [Required]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(50)]
        public string Yazar { get; set; }

        [Range(1900, 2100)]
        public int Yil { get; set; }

        [Required]
        [StringLength(20)]
        public string Durum { get; set; }
    }
}
