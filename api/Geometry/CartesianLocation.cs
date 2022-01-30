namespace api.Geometry;
public class CartesianLocation
{

  public double X { get; init; }
  public double Y { get; init; }

  public CartesianLocation Move(double deltaX, double deltaY)
  {
    return new CartesianLocation { X = X + deltaX, Y = Y + deltaY };
  }

  public static CartesianLocation? Of(double? x, double? y)
  {
    if (x is null || y is null)
    {
      return null;
    }
    return new CartesianLocation { X = (double)x, Y = (double)y };
  }

  public double Distance(CartesianLocation other)
  {
    var deltaX = X - other.X;
    var deltaY = Y - other.Y;
    return Math.Sqrt(deltaY * deltaY + deltaX * deltaX);
  }
}
