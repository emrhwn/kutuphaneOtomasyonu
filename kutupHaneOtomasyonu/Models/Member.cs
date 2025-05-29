using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutupHaneOtomasyonu.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Phone, StringLength(20)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime JoinDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime MembershipDate { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
