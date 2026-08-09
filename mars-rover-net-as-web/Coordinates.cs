namespace mars_rover_net_as_web;

public record Coordinates(int X, int Y)
{
    public Coordinates Translate((int x, int y) delta) => new(X + delta.x, Y + delta.y);
}
