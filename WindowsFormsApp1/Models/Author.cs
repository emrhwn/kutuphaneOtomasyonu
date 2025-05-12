using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Biography { get; set; }

        // Navigation property
        public virtual ICollection<Book> Books { get; set; }
    }
} 