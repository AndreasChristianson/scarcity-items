namespace api.Models;


public abstract record GameObjectTemplate<T>(
  Guid Id


  ) : IHasId where T:GameObjectInstance<T>
{
}
