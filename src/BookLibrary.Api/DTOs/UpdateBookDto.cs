namespace BookLibrary.Api.DTOs;

public class UpdateBookDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime PublishDate { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
}