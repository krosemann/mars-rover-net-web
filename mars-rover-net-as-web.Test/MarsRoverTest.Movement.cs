using mars_rover_net_as_web.Commands;

namespace mars_rover_net_as_web.Test;

public sealed class MarsRoverMovementTest
{
    [TestCase(1, 1, Orientation.North, 1, 2)]
    [TestCase(2, 3, Orientation.East, 3, 3)]
    [TestCase(5, 8, Orientation.South, 5, 7)]
    [TestCase(13, 21, Orientation.West, 12, 21)]
    public void MarsRover_MovesForward(
        int startX,
        int startY,
        Orientation startOrientation,
        int expectedX,
        int expectedY
    )
    {
        var finalPosition = new MoveForward()
            .AppliedTo(new MarsRover(startX, startY, startOrientation));

        Assert.That(finalPosition, Is.EqualTo(new MarsRover(expectedX, expectedY, startOrientation)));
    }

    [TestCase(1, 1, Orientation.North, 1, 0)]
    [TestCase(2, 3, Orientation.East, 1, 3)]
    [TestCase(5, 8, Orientation.South, 5, 9)]
    [TestCase(13, 21, Orientation.West, 14, 21)]
    public void MarsRover_MovesBackward(
        int startX,
        int startY,
        Orientation startOrientation,
        int expectedX,
        int expectedY
    )
    {
        var finalPosition = new MoveBackward()
            .AppliedTo(new MarsRover(startX, startY, startOrientation));

        Assert.That(finalPosition, Is.EqualTo(new MarsRover(expectedX, expectedY, startOrientation)));
    }
}
