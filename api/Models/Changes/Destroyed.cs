namespace api.Models;


public record Destroyed<T>(
    Guid Id,
    DateTime TimeStamp,
    long GameTime,

    GameObjectInstance<T> GameObjectInstance,
    Guid GameObjectInstanceId
  ) : Change<T>(
    Id,
    TimeStamp,
    GameTime,
    GameObjectInstance,
    GameObjectInstanceId
  ) where T: GameObjectInstance<T>
{
}
