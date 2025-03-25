using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Roulette roulette = new Roulette();
        RobotManager robotManager = new RobotManager();

        await roulette.LaunchRoulette();
    }
}