using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorFirst { get; set; }

        [Required]
        public string AuthorLast { get; set; }


        [Required]
        public string Publisher { get; set; }

        [Required(ErrorMessage ="ISBN must be in ###-########## format")]
        [RegularExpression(@"([0-9]{3})[-]([0-9]{10}$")]
        public string ISBN { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
