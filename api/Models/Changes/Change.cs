namespace api.Models;


public abstract record Change<T> (
  Guid Id,
  DateTime TimeStamp,
  long GameTime,

  GameObjectInstance<T> GameObjectInstance,
  Guid GameObjectInstanceId
  ) : IHasId where T: GameObjectInstance<T>
{
}
