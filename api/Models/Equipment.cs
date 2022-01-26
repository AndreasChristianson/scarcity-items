namespace api;

public class Equipment: Item {
  public Slot Slot { get; init; }
}

public enum Slot{
  MAIN_HAND,
  OFF_HAND,
  CHEST,
  HANDS
}
