using System.ComponentModel.DataAnnotations;
namespace APIDevelopment.WithEFCore.Data.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public required string Title { get; set; }
    public Author? Author { get; set; }
    public DateTime PublishedDate { get; set; }
}
