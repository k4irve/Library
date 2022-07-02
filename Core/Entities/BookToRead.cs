using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
/// <summary>
/// Class to be used in the BooksToRead table
/// </summary>
public class BookToRead
{
    [Key]
    public int Id { get; set; }

    public string? Title { get; set; }
}