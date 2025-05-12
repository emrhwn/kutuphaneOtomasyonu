using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        public DateTime MembershipDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        // Navigation properties
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
} 