namespace mars_rover_net_as_web;

public sealed class MarsRover(Coordinates coordinates, Orientation orientation)
{
    public MarsRover(int x, int y, Orientation orientation) : this(new Coordinates(x, y), orientation) { }

    public Coordinates Coordinates { get; } = coordinates;
    public Orientation Orientation { get; } = orientation;
}
