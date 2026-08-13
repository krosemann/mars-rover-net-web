using mars_rover_net_as_web.Commands;
using static mars_rover_net_as_web.Test.CommandsFromStrings;

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
        var finalPosition = new TurnRight().AppliedTo(new MarsRover(initialCoordinates, initialOrientation));

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
        var finalPosition = new TurnLeft().AppliedTo(new MarsRover(initialCoordinates, initialOrientation));

        Assert.Multiple(() =>
            {
                Assert.That(finalPosition.Orientation, Is.EqualTo(endOrientation));
                Assert.That(finalPosition.Coordinates, Is.EqualTo(initialCoordinates));
            }
        );
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
