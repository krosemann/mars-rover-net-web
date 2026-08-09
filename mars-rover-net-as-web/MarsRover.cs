namespace mars_rover_net_as_web;

public sealed class MarsRover(int x, int y, Direction direction)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public Direction Direction { get; } = direction;

    public MarsRover MoveForward() =>
        Direction switch {
            Direction.North => new MarsRover(X, Y + 1, Direction),
            Direction.East => new MarsRover(X + 1, Y, Direction),
            Direction.South => new MarsRover(X, Y - 1, Direction),
            Direction.West => new MarsRover(X - 1, Y, Direction),
            _ => throw new ArgumentOutOfRangeException()
        };
}
