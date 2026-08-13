using mars_rover_net_as_web.Commands;
using static mars_rover_net_as_web.Test.CommandsFromStrings;

namespace mars_rover_net_as_web.Test;

public sealed class MarsRoverInstructionsTest
{
    [TestCase(1, 1, Orientation.North, new[] { MOVE_FORWARD, TURN_RIGHT, MOVE_FORWARD, MOVE_FORWARD }, 3, 2, Orientation.East)]
    [TestCase(2, 3, Orientation.East, new[] { MOVE_BACKWARD, TURN_LEFT, MOVE_FORWARD, TURN_LEFT }, 1, 4, Orientation.West)]
    [TestCase(5, 8, Orientation.South, new[] { TURN_LEFT, MOVE_FORWARD, TURN_RIGHT, MOVE_BACKWARD }, 6, 9, Orientation.South)]
    [TestCase(
        13,
        21,
        Orientation.West,
        new[]
        {
            MOVE_FORWARD,
            TURN_RIGHT,
            MOVE_BACKWARD,
            MOVE_BACKWARD,
            TURN_RIGHT,
            MOVE_FORWARD,
            TURN_LEFT
        },
        13,
        19,
        Orientation.North
    )]
    public void ExecutesCommandSequence(
        int startX,
        int startY,
        Orientation startOrientation,
        string[] commands,
        int expectedX,
        int expectedY,
        Orientation expectedOrientation
    )
    {
        var initialPosition = new MarsRover(startX, startY, startOrientation);
        var finalState = new CommandsFromStrings(commands).Value.ExecutedFrom(initialPosition);

        Assert.That(finalState, Is.EqualTo(new MarsRover(expectedX, expectedY, expectedOrientation)));
    }

    [TestCase(1, 1, Orientation.North, new[] { MOVE_FORWARD, MOVE_FORWARD }, 1, 3)]
    [TestCase(2, 3, Orientation.East, new[] { MOVE_BACKWARD, MOVE_FORWARD }, 2, 3)]
    [TestCase(5, 8, Orientation.South, new[] { MOVE_BACKWARD, MOVE_BACKWARD, MOVE_BACKWARD }, 5, 11)]
    [TestCase(13, 21, Orientation.West, new[] { MOVE_FORWARD, MOVE_FORWARD, MOVE_BACKWARD, MOVE_FORWARD }, 11, 21)]
    public void MovesForwardAndBackward_WithoutChangingOrientation(
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
}
