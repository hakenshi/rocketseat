using Livraria.Models;
using Livraria.Models.Enums;
using Livraria.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private static List<Book> books = new List<Book>()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Title = "O Nome do Vento",
            Author = "Patrick Rothfuss",
            Genre = BookGenre.FICTION.ToString(),
            Price = 79.90m,
            Stock = 12,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "Orgulho e Preconceito",
            Author = "Jane Austen",
            Genre = BookGenre.ROMANCE.ToString(),
            Price = 39.90m,
            Stock = 25,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "O Assassinato no Expresso do Oriente",
            Author = "Agatha Christie",
            Genre = BookGenre.MYSTERY.ToString(),
            Price = 44.90m,
            Stock = 18,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "Operação Trovoada",
            Author = "Frederick Forsyth",
            Genre = BookGenre.ACTION.ToString(),
            Price = 49.90m,
            Stock = 9,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "O Iluminado",
            Author = "Stephen King",
            Genre = BookGenre.HORROR.ToString(),
            Price = 59.90m,
            Stock = 7,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "O Programador Pragmático",
            Author = "Andrew Hunt & David Thomas",
            Genre = BookGenre.WORK.ToString(),
            Price = 89.90m,
            Stock = 14,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "1984",
            Author = "George Orwell",
            Genre = BookGenre.FICTION.ToString(),
            Price = 34.90m,
            Stock = 30,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "Drácula",
            Author = "Bram Stoker",
            Genre = BookGenre.HORROR.ToString(),
            Price = 29.90m,
            Stock = 11,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        }
    };

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Book>> Index()
    {
        return books;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Book> Show(Guid id)
    {
        var book = books.FindIndex(b => b.Id == id);

        if (book == -1)
        {
            return NotFound();
        }

        return books[book];
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<Book> Store([FromBody] CreateBookRequest createBook)
    {
        var isDuplicate = books.Any(b => b.Author == createBook.Author && b.Title == createBook.Title);

        if (isDuplicate)
        {
            return Conflict();
        }

        var newBook = new Book
        {
            Id = Guid.NewGuid(),
            Author = createBook.Author,
            Title = createBook.Title,
            Stock = createBook.Stock,
            Price = createBook.Price,
            Genre = createBook.Genre.ToString(),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        books.Add(newBook);

        return newBook;
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult Update(Guid id, [FromBody] UpdateBookRequest req)
    {
        var idx = books.FindIndex(b => b.Id == id);
        if (idx == -1) return NotFound();

        var current = books[idx];

        var finalTitle = req.Title ?? current.Title;
        var finalAuthor = req.Author ?? current.Author;
        var finalGenre = req.Genre?.ToString() ?? current.Genre;
        var finalPrice = req.Price ?? current.Price;
        var finalStock = req.Stock ?? current.Stock;

        var isDuplicate = books.Any(b =>
            b.Id != id &&
            b.Title == finalTitle &&
            b.Author == finalAuthor);
        if (isDuplicate) return Conflict();

        books[idx] = new Book
        {
            Id = current.Id,
            Title = finalTitle,
            Author = finalAuthor,
            Genre = finalGenre,
            Price = finalPrice,
            Stock = finalStock,
            CreatedAt = current.CreatedAt,
            UpdatedAt = DateTime.UtcNow
        };

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var bookIndex = books.FindIndex(b => b.Id == id);
        if (bookIndex == -1)
        {
            return NotFound();
        }

        books.RemoveAt(bookIndex);
        return NoContent();
    }
}