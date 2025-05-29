using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutupHaneOtomasyonu.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }

        public int PublicationYear { get; set; }

        [Required]
        public int TotalCopies { get; set; }

        [Required]
        public int AvailableCopies { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Computed property - veritabanında saklanmaz
        [NotMapped]
        public bool IsAvailable
        {
            get { return AvailableCopies > 0; }
        }

        // Navigation properties
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        // Constructor
        public Book()
        {
            Loans = new HashSet<Loan>();
            Reservations = new HashSet<Reservation>();
        }
    }
}