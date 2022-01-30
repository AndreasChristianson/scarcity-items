namespace api.Models;


public abstract record GameObjectInstance<T>(
  Guid Id,
  Guid TemplateId,
  Guid? ParentGameObjectInstanceId
):IHasId where T: GameObjectInstance<T>{
  public List<Modifier<T>> Modifiers { get; init; } = null!;  
 public IEnumerable<Change<T>> History { get; init; } = null!;
  public GameObjectTemplate<T> Template { get; init; } = null!;
}
 