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
        public virtual Member Member { get; set; }

        public DateTime ReservationDate { get; set; }

        [Required, StringLength(20)]
        public string Status { get; set; }  // "Beklemede", "Tamamlandı", "İptal"
    }
}
