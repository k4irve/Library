using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class BookToBuy
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public double? Amount { get; set; }
}