using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutupHaneOtomasyonu.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LoanDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? ReturnDate { get; set; }

        [Column(TypeName = "decimal")]
        public decimal FineAmount { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? Fine { get; set; }

        public string Notes { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

    }
}
