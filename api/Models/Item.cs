namespace api;

public abstract  class Item {
  public Guid Id { get; init; }
  public Uri? Icon { get; init; }
  public string? Description { get; init; }
}
