using mars_rover_net_as_web.Commands;

namespace mars_rover_net_as_web;

public sealed class MarsRoverInstructions(MarsRover initialRover, string[] commands)
{
    public const string MOVE_FORWARD = "forward";
    public const string MOVE_BACKWARD = "backward";
    
    public MarsRover InitialRover { get; } = initialRover;
    private readonly Command[] _commands = [
        .. commands.Select<string, Command>(command => command switch
            {
                "f" or "F" or MOVE_FORWARD => new MoveForward(),
                "b" or "B" or MOVE_BACKWARD => new MoveBackward(),
                _ => throw new ArgumentException($"Invalid rover command {command}")
            }
        )
    ];

    // TODO - lazy evaluate
    public IEnumerable<MarsRover> Sequence()
    {
        var current = InitialRover;
        yield return current;
        foreach (var command in _commands)
        {
            current = command.Apply(current);
            yield return current;
        }
    }

    public MarsRover FinalState() => Sequence().Last();
}
