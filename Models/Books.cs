using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5.Models
{
    public class Books
    {
        //primary key
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        //no non atomic fields
        [Required]
        public string AuthorFirst { get; set; }

        [Required]
        public string AuthorLast { get; set; }


        [Required]
        public string Publisher { get; set; }

        //regular expression validation
        [Required(ErrorMessage ="ISBN must be in ###-########## format")]
        [RegularExpression(@"([0-9]{3})[-]([0-9]{10}$")]
        public string ISBN { get; set; }

        //split up the filed category and classification
        [Required]
        public string Category { get; set; }

        [Required]
        public string Classification { get; set; }

        //make this a currency
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
