using APIDevelopment.WithEFCore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDevelopment.WithEFCore.Data;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(b => b.Books)
            .HasForeignKey(b => b.AuthorId);
        modelBuilder.Entity<Author>().HasData(
            new Author { Id = 1, Name = "J K Rowling" },
            new Author { Id = 2, Name = "A P J Abdul Kalam" },
            new Author { Id = 3, Name = "J R R Tolkien" }
            );
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, AuthorId = 1, Title = "Harry Potter: The Philosophers stone", PublishedDate = new(2000, 12, 1) },
            new Book { Id = 2, AuthorId = 2, Title = "Wings of Fire", PublishedDate = new(2002, 12, 1) },
            new Book { Id = 3, AuthorId = 3, Title = "The Hobbit", PublishedDate = new(2003, 12, 1) }
            );
    }
}
