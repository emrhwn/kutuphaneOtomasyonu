using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal? FineAmount { get; set; }

        // Navigation properties
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
} 