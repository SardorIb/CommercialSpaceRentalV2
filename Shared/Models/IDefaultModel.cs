namespace Shared.Models
{
  public interface IDefaultModel
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

  }
}
