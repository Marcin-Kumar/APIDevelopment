using APIDevelopment.WithEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDevelopment.WithEFCore.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}
