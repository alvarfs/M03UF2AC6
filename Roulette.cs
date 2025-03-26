using System.Text.Json;
using System.Threading;
using System.Net.Http;
using System.Linq;

class Roulette
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int Tickets { get; set; }

    public Roulette(string name)
    {
        Name = name;
        Score = 0;
        Tickets = 10;
    }

    // Realiza una tirada de la ruleta
    public async Task<int[]> LaunchRoulette()
    {
        if (Tickets <= 0) return new int[0];

        Console.Clear();
        char[] randomSlots = { '$', '%', '@', '#', '&', '+', '!', '?', '¿', '7' };
        char[] finalSlots = { '#', '$', '7' };
        Random random = new Random();

        int[] lastRoll = await GetRobotRoll();

        for (var i = 0; i < 20; i++)
        {
            RollAnimation(randomSlots, random);
            Thread.Sleep(80);
            Console.Clear();
        }

        ShowFinalRoll(lastRoll, finalSlots, random);
        ShowResult(lastRoll);

        return lastRoll;
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
                UI.Write("--> | ", 4);
                WinnerRoll(lastRoll, slots);
                UI.Write(" <--", 4);
            }

            else 
            {
                UI.Write("    | ", 4);
                RandomRoll(slots, random);
            }

            Console.WriteLine();
            UI.WriteLine("    +-+-+-+-+-+", 4);
        }
    }

    // Muestra el resultado en base a tu combinación
    public void ShowResult(int[] roll)
    {
        // Comprobar:
        // if Triple
        // elif Double
        // else No Combo
    }

    // Animación de la tirada mientras esperamos la combinación final
    public void RollAnimation(char[] slots, Random random)
    {
        UI.WriteLine("    +-+-+-+-+-+", 4);
        for (var i = 0; i < 3; i++)
        {
            if (i == 1) UI.Write("--> | ", 4);

            else UI.Write("    | ");

            RandomRoll(slots, random);

            if (i == 1) UI.Write(" <--", 4);

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
                UI.Write($"|");
            }
        }
    }
}