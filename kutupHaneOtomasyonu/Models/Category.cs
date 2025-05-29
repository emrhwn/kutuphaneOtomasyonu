using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kutupHaneOtomasyonu.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        // Navigation Property
        public virtual ICollection<Book> Books { get; set; }

        // Constructor
        public Category()
        {
            Books = new HashSet<Book>();
        }

        // Override ToString for display purposes
        public override string ToString()
        {
            return Name;
        }
    }
}