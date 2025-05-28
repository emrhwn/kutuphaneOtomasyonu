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

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

        [StringLength(20)]
        public string ISBN { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int PublicationYear { get; set; }

        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public string Description { get; set; } // BU SATIRI EKLEYİN

    }
}
