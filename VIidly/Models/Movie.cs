
using System;
using System.ComponentModel.DataAnnotations;

namespace VIidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }

        
        [Display (Name ="Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        
        [Display(Name = "Realease Date")]
        public DateTime ReleaseDate { get; set; }

        
        [Display(Name = "Number In Stock")]
        [Range(1,100)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

    }
}