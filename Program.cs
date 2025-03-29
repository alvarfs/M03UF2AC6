using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Menu.MainTitle();

        SlotMachine slotMachine = new SlotMachine(Menu.EnterUsername());
        RobotManager robotManager = new RobotManager();
        Rankings rankings = new Rankings();

        bool exitGame = false;

        do
        {
            switch (Menu.MainLobby(slotMachine))
            {
                case 1:
                    List<int[]> result = await slotMachine.LaunchSlotMachine();
                    Console.WriteLine();

                    if (result.Count == 0)
                        UI.WriteLine("You don't have more coins...", 6, 10);
                    else
                    {
                        robotManager.GenerateRobots(result);
                        slotMachine.mainPlayer.RobotScore = robotManager.CurrentRobotScore();
                        slotMachine.mainPlayer.SetNewScore();

                        if (slotMachine.mainPlayer.Coins > 6)
                            UI.WriteLine($"COINS LEFT: {slotMachine.mainPlayer.Coins}", 2, 15);
                        else if (slotMachine.mainPlayer.Coins > 3)
                            UI.WriteLine($"COINS LEFT: {slotMachine.mainPlayer.Coins}", 1, 15);
                        else
                            UI.WriteLine($"COINS LEFT: {slotMachine.mainPlayer.Coins}", 6, 30);
                    }

                    break;
                
                case 2:
                    slotMachine.mainPlayer.ShowCurrentScore();
                    break;
                
                case 3:
                    robotManager.ShowRobotCollections();
                    break;

                case 4:
                    rankings.SaveRanking(slotMachine.mainPlayer);
                    break;

                case 5:
                    rankings.ShowTopRankings();
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