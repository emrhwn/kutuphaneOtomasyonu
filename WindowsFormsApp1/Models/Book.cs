using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        [StringLength(20)]
        [Index(IsUnique = true)]
        public string ISBN { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }

        public int? PublicationYear { get; set; }

        [Required]
        public int TotalCopies { get; set; }

        [Required]
        public int AvailableCopies { get; set; }

        // Navigation properties
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
} 