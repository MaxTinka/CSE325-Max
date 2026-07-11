using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    [Display(Name = "Title")]
    public string? Title { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }

    [Required]
    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Required]
    [Display(Name = "Rating")]
    [Range(1, 10)]
    public string? Rating { get; set; }

    // Computed property for Year (used for search by year)
    public int Year => ReleaseDate.Year;
}