using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Livraria.Models.Enums;

namespace Livraria.Requests;

public class CreateBookRequest
{
    [Required]
    [StringLength(maximumLength: 120, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [StringLength(maximumLength: 120, MinimumLength = 2)]
    public string Author { get; set; } = string.Empty;
    
    [Required]
    public BookGenre Genre { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}