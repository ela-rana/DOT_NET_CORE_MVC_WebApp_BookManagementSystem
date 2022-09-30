using System.ComponentModel.DataAnnotations;

namespace BookManagementSystem.Models
{
    public enum BookGenres
    {
        Romance,
        Mystery,
        Comedy,
        Tragedy,
        Adventure,
        Historical,
        Thriller,
        Crime,
        Horror,
        Biography,
        Autobiography,
        Childrens,
        Fantasy,
        ScienceFiction,
        Religious,
        SelfHelp,
        Other
    }

    public class Book
    {
        [Range(1,9999999999999, ErrorMessage = "ISBN must be 1-13 digits")]
        [Required(ErrorMessage ="This is a required field. Cannot be left blank")]
        public long? ISBN { get; set; }

        [Display(Name = "Book Title")]
        [MaxLength(100,ErrorMessage ="Maximum 100 characters allowed for this field")]
        [Required(ErrorMessage = "This is a required field. Cannot be left blank")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "This is a required field. Cannot be left blank")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters allowed for this field")]
        public string? Author { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(5000, ErrorMessage = "Maximum 5000 characters allowed for this field")]
        public string? Description { get; set; }

        public BookGenres Genre { get; set; }

        public string? CoverImage { get; set; }
    }
}
