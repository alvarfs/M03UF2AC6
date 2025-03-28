public class Menu
{
    public static void MainTitle()
    {
        Console.Clear();
        UI.WriteLine(@"
$$$$$$$\            $$\                 $$$$$$$\            $$\           
$$  __$$\           $$ |                $$  __$$\           $$ |          
$$ |  $$ | $$$$$$\  $$$$$$$\   $$$$$$\  $$ |  $$ |$$\   $$\ $$ | $$$$$$\  
$$$$$$$  |$$  __$$\ $$  __$$\ $$  __$$\ $$$$$$$  |$$ |  $$ |$$ |$$  __$$\ 
$$  __$$< $$ /  $$ |$$ |  $$ |$$ /  $$ |$$  __$$< $$ |  $$ |$$ |$$$$$$$$ |
$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |$$   ____|
$$ |  $$ |\$$$$$$  |$$$$$$$  |\$$$$$$  |$$ |  $$ |\$$$$$$  |$$ |\$$$$$$$\ 
\__|  \__| \______/ \_______/  \______/ \__|  \__| \______/ \__| \_______|
        ", 1);
    }

    public static string EnterUsername()
    {
        try
        {
            UI.Write("Please enter your username: ", 3, 20);
            string name = UI.ReadLine(2);
            if (name.Length >= 3) 
                return name;
            else throw 
                new Exception("Your name must be longer than 2 characters...");
        }
        catch (Exception ex)
        {
            UI.WriteLine(ex.Message, 6, 20);
            UI.NextSection();
            return EnterUsername();
        }
    }

    public static int MainLobby()
    {
        Console.Clear();

        UI.WriteLine("1. Pull Lucky Spin", 2);
        UI.WriteLine("2. Show points", 1);
        UI.WriteLine("3. Check Robots", 1);
        UI.WriteLine("4. Save Score", 1);
        UI.WriteLine("5. Show Scoreboard", 1);
        UI.WriteLine("0. Exit", 6);
        Console.WriteLine();

        UI.Write("Select a number: ", 3, 20);
        return int.Parse(UI.ReadLine(1));
    }
}