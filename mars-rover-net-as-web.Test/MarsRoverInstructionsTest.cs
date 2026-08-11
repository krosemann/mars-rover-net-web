using static mars_rover_net_as_web.MarsRoverInstructions;

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
        var finalState = new MarsRoverInstructions(
            new MarsRover(startX, startY, startOrientation),
            commands
        ).FinalState();

        Assert.Multiple(() =>
            {
                Assert.That(finalState.Coordinates, Is.EqualTo(new Coordinates(expectedX, expectedY)));
                Assert.That(finalState.Orientation, Is.EqualTo(startOrientation));
            }
        );
    }
}
