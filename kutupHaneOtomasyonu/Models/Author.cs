﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutupHaneOtomasyonu.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string Biography { get; set; }

        
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual ICollection<Book> Books { get; set; }
    }
}
