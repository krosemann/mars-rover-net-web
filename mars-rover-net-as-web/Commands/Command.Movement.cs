namespace mars_rover_net_as_web.Commands;

public sealed class MoveForward : Command
{
    public MarsRover Apply(MarsRover rover) =>
        new(
            rover.Coordinates.Translate(MovementDelta.Delta(rover.Orientation)),
            rover.Orientation
        );
}

public sealed class MoveBackward : Command
{
    public MarsRover Apply(MarsRover rover) =>
        new(
            rover.Coordinates.Translate(MovementDelta.Delta(rover.Orientation).Inverted()),
            rover.Orientation
        );
}

public static class MovementDelta
{
    public static (int x, int y) Delta(Orientation orientation) => orientation switch
    {
        Orientation.North => (0, 1),
        Orientation.East => (1, 0),
        Orientation.South => (0, -1),
        Orientation.West => (-1, 0),
        _ => throw new ArgumentOutOfRangeException()
    };
}
