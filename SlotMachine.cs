using System.Text.Json;
using System.Threading;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;

public class SlotMachine
{
    public Player mainPlayer;

    public SlotMachine(string name)
    {
        mainPlayer = new Player(name, 0);
    }

    // Arrancamos la ruleta
    public async Task<List<int[]>> LaunchSlotMachine()
    {
        List<int[]> allRolls = new List<int[]>();

        await SpinSlotMachine(allRolls);

        return allRolls;
    }

    // Realiza una tirada de la ruleta
    private async Task SpinSlotMachine(List<int[]> rolls)
    {
        if (mainPlayer.Coins <= 0) return;
        mainPlayer.Coins--;

        char[] randomSlots = { '$', '%', '@', '#', '&', '+', '!', '?', '¿', '7' };
        char[] finalSlots = { '#', '$', '7' };
        Random random = new Random();

        int[] lastRoll = await GetRobotRoll();
        rolls.Add(lastRoll);

        Console.Clear();

        for (var i = 0; i < 20; i++)
        {
            RollAnimation(randomSlots, random);
            Thread.Sleep(80);
            Console.Clear();
        }

        ShowFinalRoll(lastRoll, finalSlots, random);
        
        if (lastRoll[0] == lastRoll[1] && lastRoll[1] == lastRoll[2])
        {
            if (lastRoll[0] == 0) UI.Write("TRIPLE COMBO!! ", 0, 20);
            if (lastRoll[0] == 1) UI.Write("TRIPLE COMBO!! ", 1, 20);
            if (lastRoll[0] == 2) UI.Write("JACKPOT!! ", 2, 20);

            mainPlayer.ExtraScore += 10;
            UI.WriteLine("+10 POINTS AND EXTRA SPIN", 3, 20);
            mainPlayer.Coins++;

            UI.NextSection();
            await SpinSlotMachine(rolls);
        }
        else if (lastRoll[0] == lastRoll[1] || lastRoll[1] == lastRoll[2] || lastRoll[2] == lastRoll[0])
        {
            mainPlayer.ExtraScore += 5;
            UI.Write("DOUBLE COMBO! ", 3, 20);
            UI.WriteLine("+5 POINTS", 1, 20);
        }
    }

    // Consigue la combinación final en base la API
    public async Task<int[]> GetRobotRoll()
    {
        using HttpClient client = new HttpClient();
        string url = "https://www.randomnumberapi.com/api/v1.0/random?min=0&max=3&count=3";

        try
        {
            string response = await client.GetStringAsync(url);
            int[] numbers = JsonSerializer.Deserialize<int[]>(response)!;
            return numbers;
        }
        catch (Exception ex)
        {
            UI.WriteLine("Error: " + ex.Message);
            return new int[0];
        }
    }

    // Mostramos la combinación final en la linea central y otras de relleno
    public void ShowFinalRoll(int[] lastRoll, char[] slots, Random random)
    {
        UI.WriteLine("    +-+-+-+-+-+", 4);
        for (var i = 0; i < 3; i++)
        {
            if (i == 1) 
            {
                UI.Write("-->", 1);
                UI.Write(" | ", 4);
                WinnerRoll(lastRoll, slots);
                UI.Write(" <--", 1);
            }

            else 
            {
                UI.Write("    | ", 4);
                RandomRoll(slots, random);
            }

            Console.WriteLine();
            UI.WriteLine("    +-+-+-+-+-+", 4);
        }
        Console.WriteLine();
    }

    // Animación de la tirada mientras esperamos la combinación final
    public void RollAnimation(char[] slots, Random random)
    {
        UI.WriteLine("    +-+-+-+-+-+", 4);
        for (var i = 0; i < 3; i++)
        {
            if (i == 1)
            {
                UI.Write("-->", 1);
                UI.Write(" | ", 4);
            }
            else UI.Write("    | ", 4);

            RandomRoll(slots, random);

            if (i == 1) UI.Write(" <--", 1);

            Console.WriteLine();
            UI.WriteLine("    +-+-+-+-+-+", 4);
        }
    }

    // Combinación aleatoria
    public void RandomRoll(char[] slots, Random random)
    {
        for (var i = 0; i < 3; i++)
        {
            int selected = random.Next(0, slots.Length);
            if (i != 2) UI.Write($"{slots[selected]}  ", selected);
            else 
            {
                UI.Write($"{slots[selected]} ", selected);
                UI.Write($"|", 4);
            }
        }
    }

    // Combinación final
    public void WinnerRoll(int[] roll, char[] slots)
    {
        for (var i = 0; i < 3; i++)
        {
            int selected = roll[i];
            if (i != 2) 
                UI.Write($"{slots[selected]}  ", roll[i]);
            else 
            {
                UI.Write($"{slots[selected]} ", roll[i]);
                UI.Write($"|", 4);
            }
        }
    }
}