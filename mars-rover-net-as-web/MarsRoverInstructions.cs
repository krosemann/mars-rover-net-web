namespace mars_rover_net_as_web;

public sealed class MarsRoverInstructions(MarsRover initialRover, string[] commands)
{
    public MarsRover InitialRover { get; } = initialRover;
    private readonly IEnumerable<Func<MarsRover, MarsRover>> _commands = commands.Translate();
    
    // TODO - lazy evaluate
    public IEnumerable<MarsRover> Sequence()
    {
        var current = InitialRover;
        yield return current;
        foreach (var command in _commands)
        {
            current = command(current);
            yield return current;
        }
    }

    public MarsRover FinalState() => Sequence().Last();
}

public static class Commands
{
    public const string MOVE_FORWARD = "forward";
    public const string MOVE_BACKWARD = "backward";
    
    public static IEnumerable<Func<MarsRover, MarsRover>> Translate(this string[] commands) =>
        commands.Select(command => command switch
            {
                "f" or "F" or "forward" => MoveForwardCommand,
                "b" or "B" or "backward" => MoveBackwardCommand,
                _ => throw new ArgumentException($"Invalid rover command {command}")
            }
        );

    private static Func<MarsRover, MarsRover> MoveForwardCommand => rover => rover.Move(MoveDirection.Forward);
    private static Func<MarsRover, MarsRover> MoveBackwardCommand => rover => rover.Move(MoveDirection.Backward);
}
