using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class ReadedBook
{
    [Key]
    public int Id { get; set; }

    public string? Title { get; set; }
    public sbyte?  Rate { get; set; }
}