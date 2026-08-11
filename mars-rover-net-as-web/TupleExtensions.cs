namespace mars_rover_net_as_web;

public static class TupleExtensions
{
    public static (int x, int y) Inverted(this (int x, int y) tuple) => (tuple.x * -1, tuple.y * -1);
}
