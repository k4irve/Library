using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
/// <summary>
/// Class to be used in the BooksToBuy table
/// </summary>
public class BookToBuy
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public double? Amount { get; set; }
}