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

        public DateTime LoanDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Column(TypeName = "decimal")]
        public decimal FineAmount { get; set; }
    }
}
