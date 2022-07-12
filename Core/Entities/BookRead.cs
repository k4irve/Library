using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
/// <summary>
/// Class to be used in the ReadedBooks table
/// </summary>
public class BookRead
{
    [Key]
    public int Id { get; set; }

    public string? Title { get; set; }
    public sbyte?  Rate { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateTime PublicationDate { get; set; }
    public int Pages { get; set; }
}