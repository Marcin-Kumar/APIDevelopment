using APIDevelopment.WithEFCore.Controllers.Models;
using APIDevelopment.WithEFCore.Data;
using APIDevelopment.WithEFCore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDevelopment.WithEFCore.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _context;
    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetBooks()
    {
        return await _context.Books.Select(b => new BookDto(b.Id, b.Title, b.Author!.Name, b.PublishedDate)).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBookWithId(int id)
    {
        Book? book = await _context.Books.Include(b => b.Author).SingleOrDefaultAsync(b => b.Id == id);
        if(book == null)
        {
            return NotFound();
        }
        return Ok(new BookDto(book.Id, book.Author!.Name, book.Title, book.PublishedDate));
    }

    [HttpPost]
    public async Task<ActionResult<BookDto>> CreateBookEntry([FromBody] BookDto bookDto)
    {
        Author? author = await _context.Authors.SingleOrDefaultAsync(a => a.Name == bookDto.AuthorName);
        if (author == null)
        {
            author = new Author { Name = bookDto.AuthorName };
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
        Book book = new Book { Title = bookDto.Title, PublishedDate = bookDto.PublishedDate, AuthorId = author.Id };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(CreateBookEntry), new { id = book.Id }, bookDto with { Id = book.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookEntry(int id, [FromBody] BookDto bookDto)
    {
        if(bookDto.Id == null || bookDto.Id != id)
        {
            return BadRequest();
        }

        Author? author = await _context.Authors.SingleOrDefaultAsync(a => a.Name == bookDto.AuthorName);
        if (author == null)
        {
            author = new Author { Name = bookDto.AuthorName };
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        Book book = new Book { Id = (int)bookDto.Id, Title = bookDto.Title, PublishedDate = bookDto.PublishedDate, AuthorId = author.Id };
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookEntry(int id)
    {
        Book? book = await _context.Books.FindAsync(id);
        if(book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
