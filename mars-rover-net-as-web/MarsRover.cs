namespace mars_rover_net_as_web;

public record MarsRover(Coordinates Coordinates, Orientation Orientation)
{
    public MarsRover(int x, int y, Orientation orientation) : this(new Coordinates(x, y), orientation) { }
}
