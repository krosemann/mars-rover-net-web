namespace mars_rover_net_as_web.Commands;

public interface Command
{
    MarsRover Apply(MarsRover rover);
}
