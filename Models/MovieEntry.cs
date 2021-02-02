using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    //this is the model and class for the movies that are entered into the website
    //includes some restriction on fields tha are required or have other limitations
    public class MovieEntry
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25, ErrorMessage = "The character limit may not exceed 25.")]
        public string Notes { get; set; }

    }
}
