public class UI 
{
    // WriteLine dinamico y con colores
    public static void WriteLine(string text, int textColor = 7, int speed = 0)
    {
        Console.ForegroundColor = SelectColor(textColor);

        for (int i = 0; i < text.Length; i++)
        {
            Console.Write($"{text[i]}");
            Thread.Sleep(speed);
        } 

        Console.ResetColor();
        Console.WriteLine("");
    }

    // Write dinamico y con colores
    public static void Write(string text, int textColor = 7, int speed = 0)
    {
        Console.ForegroundColor = SelectColor(textColor);

        for (int i = 0; i < text.Length; i++)
        {
            Console.Write($"{text[i]}");
            Thread.Sleep(speed);
        } 

        Console.ResetColor();
    }

    // ReadLine dinamico y con colores
    public static string ReadLine(int textColor = 7)
    {
        Console.ForegroundColor = SelectColor(textColor);
        string text = Console.ReadLine()!;
        Console.ResetColor();

        return text;
    }

    // Transiciones
    public static void NextSection()
    {
        Console.WriteLine();
        UI.Write("Press enter to continue... ", 1);
        Console.ReadLine();
        Console.Clear();
    }

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

    // Selector de color en base a un numero
    public static ConsoleColor SelectColor(int selectedNumber)
    {
        switch (selectedNumber)
        {
            case 0: return ConsoleColor.Blue;
            case 1: return ConsoleColor.Yellow;
            case 2: return ConsoleColor.Green;
            case 3: return ConsoleColor.Magenta;
            case 4: return ConsoleColor.DarkGray;
            case 5: return ConsoleColor.DarkYellow;
            case 6: return ConsoleColor.Red;
            case 7: return ConsoleColor.Gray;
            default: return ConsoleColor.White;
        }
    }
}