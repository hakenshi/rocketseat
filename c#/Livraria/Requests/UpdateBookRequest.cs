using System.ComponentModel.DataAnnotations;
using Livraria.Models.Enums;

namespace Livraria.Requests;

public class UpdateBookRequest
{
    [StringLength(120, MinimumLength = 2)]
    public string? Title { get; set; }

    [StringLength(120, MinimumLength = 2)]
    public string? Author { get; set; }

    public BookGenre? Genre { get; set; }

    [Range(0, int.MaxValue)]
    public decimal? Price { get; set; }

    [Range(0, int.MaxValue)]
    public int? Stock { get; set; }
}