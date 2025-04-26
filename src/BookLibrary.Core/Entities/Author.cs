namespace BookLibrary.Core.Entities;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Biography { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? PhotoUrl { get; set; }
}