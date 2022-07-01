using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class BookToRead
{
    [Key]
    public int Id { get; set; }

    public string? Title { get; set; }
}