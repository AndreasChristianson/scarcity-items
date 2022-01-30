namespace api.Models;

public interface IDescribable
{
  public Uri Icon { get; }
  public string Description { get; }
  public string Name { get; }

  public static readonly Uri DEFAULT_ICON = new Uri("https://example.com");
}
