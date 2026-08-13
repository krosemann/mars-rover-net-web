using mars_rover_net_as_web.Commands;

namespace mars_rover_net_as_web.Test;

public sealed class CommandsFromStrings(IEnumerable<string> commands)
{
    public const string MOVE_FORWARD = "forward";
    public const string MOVE_BACKWARD = "backward";
    
    public const string TURN_RIGHT = "right";
    public const string TURN_LEFT = "left";

    public readonly IReadOnlyCollection<Command> Value =
    [
        .. commands.Select<string, Command>(command => command switch
            {
                "f" or "F" or MOVE_FORWARD => new MoveForward(),
                "b" or "B" or MOVE_BACKWARD => new MoveBackward(),
                "r" or "R" or TURN_RIGHT => new TurnRight(),
                "l" or "L" or TURN_LEFT => new TurnLeft(),
                _ => throw new ArgumentException($"Invalid rover command {command}")
            }
        )
    ];
}
