namespace mars_rover_net_as_web.Commands;

public sealed class TurnRight : Command
{
    public MarsRover AppliedTo(MarsRover rover) => rover with
    {
        Orientation = rover.Orientation switch
        {
            Orientation.North => Orientation.East,
            Orientation.East => Orientation.South,
            Orientation.South => Orientation.West,
            Orientation.West => Orientation.North,
            _ => throw new ArgumentOutOfRangeException()
        }
    };
}


public sealed class TurnLeft : Command
{
    public MarsRover AppliedTo(MarsRover rover) => rover with
    {
        Orientation = rover.Orientation switch
        {
            Orientation.North => Orientation.West,
            Orientation.West => Orientation.South,
            Orientation.South => Orientation.East,
            Orientation.East => Orientation.North,
            _ => throw new ArgumentOutOfRangeException()
        }
    };
}
