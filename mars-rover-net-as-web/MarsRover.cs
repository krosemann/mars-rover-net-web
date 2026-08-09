namespace mars_rover_net_as_web;

public sealed class MarsRover(Coordinates coordinates, Orientation orientation)
{
    public MarsRover(int x, int y, Orientation orientation) : this(new Coordinates(x, y), orientation) { }

    public Coordinates Coordinates { get; } = coordinates;
    public int X => Coordinates.X;
    public int Y => Coordinates.Y;

    public Orientation Orientation { get; } = orientation;

    public MarsRover Move(MoveDirection moveDirection) =>
        new(
            Coordinates.Translate(EffectiveDelta(moveDirection)),
            Orientation
        );

    private (int x, int y) EffectiveDelta(MoveDirection moveDirection) =>
        Delta() * (moveDirection == MoveDirection.Forward ? 1 : -1);

    private (int x, int y) Delta() => Orientation switch
    {
        Orientation.North => (0, 1),
        Orientation.East => (1, 0),
        Orientation.South => (0, -1),
        Orientation.West => (-1, 0),
        _ => throw new ArgumentOutOfRangeException()
    };
}

public enum MoveDirection
{
    Forward,
    Backward
}
