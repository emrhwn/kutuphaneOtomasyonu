using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutupHaneOtomasyonu.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı adı 3-50 karakter arasında olmalıdır")]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [StringLength(20)]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Rol zorunludur")]
        [StringLength(20)]
        public string Role { get; set; }  // "Admin", "Kullanıcı"

        [Column(TypeName = "datetime2")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? LastLoginDate { get; set; }

        public bool IsActive { get; set; }

        // Constructor
        public User()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        // Navigation Properties (ilişkili tablolar için)
        // Örnek: Kullanıcının ödünç aldığı kitaplar
        // public virtual ICollection<Loan> Loans { get; set; }
    }
}