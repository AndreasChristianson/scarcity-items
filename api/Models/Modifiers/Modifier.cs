namespace api.Models;


public abstract record Modifier<T>(
  Guid Id,
  Uri Icon,
  string Description,
  string Name
  ) : IDescribable, IHasId  where T : GameObjectInstance<T>{
  public abstract T Apply(T gameObjectInstance);
}
