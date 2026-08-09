namespace mars_rover_net_as_web.Test;

public class Tests
{
    [TestCase(1, 1, Direction.North, 1, 2)]
    [TestCase(2, 3, Direction.East, 3, 3)]
    [TestCase(5, 8, Direction.South, 5, 7)]
    [TestCase(13, 21, Direction.West, 12, 21)]
    public void MarsRover_MovesForward(
        int startX,
        int startY,
        Direction startDirection,
        int expectedX,
        int expectedY
    )
    {
        var rover = new MarsRover(startX, startY, startDirection).MoveForward();
        Assert.That(
            (rover.X, rover.Y),
            Is.EqualTo((expectedX, expectedY))
        );
    }
}
