using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Menu.MainTitle();

        Roulette roulette = new Roulette(Menu.EnterUsername());
        RobotManager robotManager = new RobotManager();
        Rankings rankings = new Rankings();

        bool exitGame = false;

        do
        {
            switch (Menu.MainLobby())
            {
                case 1:
                    List<int[]> result = await roulette.LaunchRoulette();

                    if (result.Count == 0)
                    {
                        Console.WriteLine();
                        UI.WriteLine("You dont have more coins...", 6, 10);
                    } 
                    else
                    {
                        robotManager.GenerateRobots(result);

                        if (roulette.mainPlayer.Coins > 3)
                            UI.WriteLine($"COINS LEFT: {roulette.mainPlayer.Coins}", 1, 15);
                        else
                            UI.WriteLine($"COINS LEFT: {roulette.mainPlayer.Coins}", 6, 30);
                    }

                    break;
                
                case 2:
                    Console.Clear();

                    UI.WriteLine($"ROBOT POINTS: {robotManager.CurrentRobotScore()}", 3, 30);
                    UI.WriteLine($"EXTRA POINTS: {roulette.mainPlayer.Score}", 1, 30);
                    UI.WriteLine($"TOTAL SCORE: {roulette.mainPlayer.Score + robotManager.CurrentRobotScore()}", 2, 30);
                    break;
                
                case 3:
                    robotManager.ShowRobotCollections();
                    break;

                case 0:
                    exitGame = true;
                    break;

                default:
                    UI.WriteLine("Unknown option, please try again...", 4, 10);
                    break;
            }

            UI.NextSection();

        } while (!exitGame);

        UI.WriteLine("BYE BYE! :P", 1, 20);

    }

}