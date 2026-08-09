namespace mars_rover_net_as_web;

public static class TupleExtensions
{
    extension((int x, int y))
    {
        public static (int x, int y) operator *((int x, int y) tuple, int factor) =>
            (tuple.x * factor, tuple.y * factor);
    }
}
