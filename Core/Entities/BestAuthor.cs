using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class BestAuthor
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}