namespace mars_rover_net_as_web.Commands;

public interface Command
{
    MarsRover Apply(MarsRover rover);
}

public static class CommandExtensions
{
    public static IReadOnlyCollection<MarsRover> AsExecutedSequence(
        this IEnumerable<Command> commands,
        MarsRover initialRover
    )
    {
        var marsRoverStates = new List<MarsRover> { initialRover };
        foreach (var command in commands)
        {
            var current = marsRoverStates.Last();
            marsRoverStates.Add(command.Apply(current));
        }

        return marsRoverStates.AsReadOnly();
    }

    public static MarsRover ExecutedFrom(
        this IEnumerable<Command> commands,
        MarsRover initialRover
    ) =>
        commands.AsExecutedSequence(initialRover).Last();
}
