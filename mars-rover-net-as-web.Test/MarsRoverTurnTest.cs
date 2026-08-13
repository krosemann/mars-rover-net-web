using mars_rover_net_as_web.Commands;

namespace mars_rover_net_as_web.Test;

public sealed class MarsRoverTurnTest
{
    [TestCase(Orientation.North, Orientation.East)]
    [TestCase(Orientation.East, Orientation.South)]
    [TestCase(Orientation.South, Orientation.West)]
    [TestCase(Orientation.West, Orientation.North)]
    public void TurnsRight_Once(Orientation initialOrientation, Orientation endOrientation)
    {
        var initialCoordinates = new Coordinates(1, 1);
        var finalPosition = new TurnRight().Apply(new MarsRover(initialCoordinates, initialOrientation));

        Assert.Multiple(() =>
            {
                Assert.That(finalPosition.Orientation, Is.EqualTo(endOrientation));
                Assert.That(finalPosition.Coordinates, Is.EqualTo(initialCoordinates));
            }
        );
    }
    
    [TestCase(Orientation.North, Orientation.West)]
    [TestCase(Orientation.West, Orientation.South)]
    [TestCase(Orientation.South, Orientation.East)]
    [TestCase(Orientation.East, Orientation.North)]
    public void TurnsLeft_Once(Orientation initialOrientation, Orientation endOrientation)
    {
        var initialCoordinates = new Coordinates(1, 1);
        var finalPosition = new TurnLeft().Apply(new MarsRover(initialCoordinates, initialOrientation));

        Assert.Multiple(() =>
            {
                Assert.That(finalPosition.Orientation, Is.EqualTo(endOrientation));
                Assert.That(finalPosition.Coordinates, Is.EqualTo(initialCoordinates));
            }
        );
    }
}
