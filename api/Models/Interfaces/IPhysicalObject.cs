namespace api.Models;


public interface IPhysicalObject {
  public double Weight { get; }
  public double Volume { get; }

  public bool DoesItFit(IPhysicalObject space) {
    return space.Volume > Volume && space.Weight > Weight;
  }
}
