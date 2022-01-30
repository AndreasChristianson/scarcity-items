using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;


public record Created<T>(
    Guid Id,
    DateTime TimeStamp,
    long GameTime,

    GameObjectInstance<T> gameObjectInstance,
    Guid GameObjectInstanceId,

    long TemplateSeed,

    Guid GameObjectTemplateId,
    GameObjectTemplate<T> gameObjectTemplate,

    Guid? Parent,
    double? X,
    double? Y

  ) : Change<T>(
    Id,
    TimeStamp,
    GameTime,
    gameObjectInstance,
    GameObjectInstanceId
  ) where T: GameObjectInstance<T>
{

}
