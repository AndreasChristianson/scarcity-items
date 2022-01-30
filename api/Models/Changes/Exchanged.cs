namespace api.Models;


public record Exchanged<T>(
    Guid Id,
    DateTime TimeStamp,
    long GameTime,

    GameObjectInstance<T> GameObjectInstance,
    Guid GameObjectInstanceId,

    Guid NewParent

  ) : Change<T>(
    Id,
    TimeStamp,
    GameTime,
    GameObjectInstance,
    GameObjectInstanceId
  )where T: GameObjectInstance<T>
{
}
