using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutupHaneOtomasyonu.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public virtual Member Member { get; set; }
        public int? CreatedByUserId { get; set; }

        public virtual User CreatedByUser { get; set; }

        public DateTime ReservationDate { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; }  // "Beklemede", "Tamamlandı", "İptal"
    }
}
