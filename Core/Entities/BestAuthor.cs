using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
/// <summary>
/// Class to be used in the BestAuthors table
/// </summary>
public class BestAuthor
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}