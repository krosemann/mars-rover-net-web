namespace mars_rover_net_as_web;

public static class TupleExtensions
{
    public static (int x, int y) Multiply(this (int x, int y) tuple, int factor) =>
        (tuple.x * factor, tuple.y * factor);
}
