using Livraria.Requests;

namespace Livraria.Models;

public class Book
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Genre { get; set; }
    public required decimal Price { get; set; }
    public required int Stock { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}