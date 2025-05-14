namespace APIDevelopment.WithEFCore.Controllers.Models;

public record BookDto(int? Id, string Title,string AuthorName, DateTime PublishedDate);
