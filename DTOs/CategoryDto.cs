public class CategoryDto
{
  public Guid CategoryId { get; set; }
  public required string Name { get; set; }
  public string Slug { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
}