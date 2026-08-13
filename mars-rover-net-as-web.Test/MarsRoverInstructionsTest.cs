using mars_rover_net_as_web.Commands;
using static mars_rover_net_as_web.Test.CommandsFromStrings;

namespace mars_rover_net_as_web.Test;

public sealed class MarsRoverInstructionsTest
{
    [TestCase(1, 1, Orientation.North, new[] { MOVE_FORWARD, MOVE_FORWARD }, 1, 3)]
    [TestCase(2, 3, Orientation.East, new[] { MOVE_BACKWARD, MOVE_FORWARD }, 2, 3)]
    [TestCase(5, 8, Orientation.South, new[] { MOVE_BACKWARD, MOVE_BACKWARD, MOVE_BACKWARD }, 5, 11)]
    [TestCase(13, 21, Orientation.West, new[] { MOVE_FORWARD, MOVE_FORWARD, MOVE_BACKWARD, MOVE_FORWARD }, 11, 21)]
    public void MarsRover_MovesForwardAndBackward_InSequence(
        int startX,
        int startY,
        Orientation startOrientation,
        string[] commands,
        int expectedX,
        int expectedY
    )
    {
        var initialPosition = new MarsRover(startX, startY, startOrientation);
        var finalState = new CommandsFromStrings(commands).Value.ExecutedFrom(initialPosition);

        Assert.That(finalState, Is.EqualTo(new MarsRover(expectedX, expectedY, startOrientation)));
    }

    [TestCase(Orientation.North, TURN_RIGHT)]
    [TestCase(Orientation.North, TURN_LEFT)]
    [TestCase(Orientation.East, TURN_RIGHT)]
    [TestCase(Orientation.East, TURN_LEFT)]
    [TestCase(Orientation.South, TURN_RIGHT)]
    [TestCase(Orientation.South, TURN_LEFT)]
    [TestCase(Orientation.West, TURN_RIGHT)]
    [TestCase(Orientation.West, TURN_LEFT)]
    public void FourTurns_ReturnIdentity(Orientation orientation, string command)
    {
        var initialPosition = new MarsRover(1, 1, orientation);
        var instructions = new CommandsFromStrings(Enumerable.Repeat(command, 4)).Value;
        var finalPosition = instructions.ExecutedFrom(initialPosition);

        Assert.That(finalPosition, Is.EqualTo(initialPosition));
    }
}
