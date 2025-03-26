using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        UI.MainTitle();

        Roulette roulette = new Roulette(UI.EnterUsername());
        RobotManager robotManager = new RobotManager();

        int[] result = await roulette.LaunchRoulette();

        if (result.Length == 0)
            UI.WriteLine("You dont have more tickets...", 6, 10);

        foreach (var item in result)
        {
            Console.Write($"{item} ");
        }

        // Panel a realizar:
        // 1. Pull Lucky Spin
        // 2. Show points
        // 3. Check Robots
        // 4. Show Scoreboard
        // 0. Exit
    }


}