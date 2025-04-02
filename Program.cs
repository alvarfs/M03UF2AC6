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
            switch (Menu.MainLobby(slotMachine.mainPlayer.Coins))
            {
                case 1:
                    if (slotMachine.mainPlayer.Coins > 0)
                        await StartGambling(slotMachine, robotManager, rankings);
                    else
                        UI.WriteLine("You don't have more coins...", 6, 10);
                    
                    break;
                
                case 2:
                    slotMachine.mainPlayer.ShowCurrentScore();
                    break;
                
                case 3:
                    robotManager.ShowRobotCollections();
                    break;

                case 4:
                    rankings.ShowTopRankings();
                    break;

                case 0:
                    exitGame = true;
                    break;

                default:
                    UI.WriteLine("Unknown option, please try again...", 4, 30);
                    break;
            }

            UI.NextSection();

        } while (!exitGame);

        UI.WriteLine("BYE BYE! :P", 1, 20);

    }

    public static async Task StartGambling(SlotMachine slot, RobotManager robotManager, Rankings ranks)
    {
        bool goGambling = false;
        do
        {
            List<int[]> result = await slot.LaunchSlotMachine();
            slot.ShowResult(result, robotManager);   

            if (slot.mainPlayer.Coins > 0)
                goGambling = slot.ContinueGambling();
            else
            {
                goGambling = false;
                ranks.SaveRanking(slot.mainPlayer);
            }

        } while (goGambling);
    }

}