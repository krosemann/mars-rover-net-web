namespace mars_rover_net_as_web;

public sealed class MarsRover(Coordinates coordinates, Direction direction)
{
    public MarsRover(int x, int y, Direction direction) : this(new Coordinates(x, y), direction) { }

    public Coordinates Coordinates { get; } = coordinates;
    public int X => Coordinates.X;
    public int Y => Coordinates.Y;

    public Direction Direction { get; } = direction;

    public MarsRover MoveForward() => Move(ForwardOrBackward.Forward);
    public MarsRover MoveBackward() => Move(ForwardOrBackward.Backward);

    private MarsRover Move(ForwardOrBackward forwardOrBackward) =>
        new(
            Coordinates.Translate(
                Delta().Multiply(forwardOrBackward == ForwardOrBackward.Forward ? 1 : -1)
            ),
            Direction
        );

    private (int x, int y) Delta() => Direction switch
    {
        Direction.North => (0, 1),
        Direction.East => (1, 0),
        Direction.South => (0, -1),
        Direction.West => (-1, 0),
        _ => throw new ArgumentOutOfRangeException()
    };

    private enum ForwardOrBackward
    {
        Forward,
        Backward
    }
}
