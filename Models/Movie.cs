using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    [Table("Movies")]
    public class Movie

    {
        public int ID { get; set; }

        [Required]
        [StringLength(60,MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name ="Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;

        [Column(TypeName = "Decimal(18,2)")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(10)]
        public string Rating { get; set; } = String.Empty;

        public Rate Rate { get; set; }

    }


   public enum Rate
    {
        Exellant,
        VeryGood,
        Good,
        Poor,
        Bad
    }


  
}
