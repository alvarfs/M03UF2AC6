using System.Text.Json;
using System.Threading;
using System.Net.Http;

class Roulette
{
    public async Task LaunchRoulette()
    {
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

        ShowLastRoll(lastRoll, finalSlots, random);
    }

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
            Console.WriteLine("Error: " + ex.Message);
            return Array.Empty<int>();
        }
    }

    public void ShowLastRoll(int[] lastRoll, char[] slots, Random random)
    {
        Console.WriteLine("    +-+-+-+-+-+");
        for (var i = 0; i < 3; i++)
        {
            if (i == 1) 
            {
                Console.Write("--> | ");
                WinnerRoll(lastRoll, slots);
                Console.Write(" <--");
            }

            else 
            {
                Console.Write("    | ");
                RandomRoll(slots, random);
            }

            Console.WriteLine();
            Console.WriteLine("    +-+-+-+-+-+");
        }
    }

    public void RollAnimation(char[] slots, Random random)
    {
        Console.WriteLine("    +-+-+-+-+-+");
        for (var i = 0; i < 3; i++)
        {
            if (i == 1) Console.Write("--> | ");

            else Console.Write("    | ");

            RandomRoll(slots, random);

            if (i == 1) Console.Write(" <--");

            Console.WriteLine();
            Console.WriteLine("    +-+-+-+-+-+");
        }
    }

    public void RandomRoll(char[] slots, Random random)
    {
        for (var i = 0; i < 3; i++)
        {
            int selected = random.Next(0, slots.Length);
            if (i != 2) Console.Write($"{slots[selected]}  ");
            else Console.Write($"{slots[selected]} |");

        }
    }

    public void WinnerRoll(int[] roll, char[] slots)
    {
        for (var i = 0; i < 3; i++)
        {
            int selected = roll[i];
            if (i != 2) Console.Write($"{slots[selected]}  ");
            else Console.Write($"{slots[selected]} |");
        }
    }
}