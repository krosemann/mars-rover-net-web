namespace mars_rover_net_as_web;

public sealed class Coordinates(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public Coordinates Translate((int x, int y) delta) => new Coordinates(X + delta.x, Y + delta.y);
}
