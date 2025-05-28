using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kutupHaneOtomasyonu.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation Property
        public virtual ICollection<Book> Books { get; set; }

        public Category()
        {
            Books = new HashSet<Book>();
        }
    }
}