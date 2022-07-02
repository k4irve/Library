using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
/// <summary>
/// Class to be used in the ReadedBooks table
/// </summary>
public class ReadedBook
{
    [Key]
    public int Id { get; set; }

    public string? Title { get; set; }
    public sbyte?  Rate { get; set; }
}