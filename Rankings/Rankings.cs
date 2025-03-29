using System.Linq;

class Rankings
{
    public string path = @".\Rankings\CurrentRankings.txt";

    // Guarda la puntuación del jugador
    public void SaveRanking(Player mainPlayer)
    {
        List<Player> currentRankings = GetTopRankings();
        currentRankings.Add(mainPlayer);

        currentRankings.OrderByDescending(rank => rank.Score);

        using (StreamWriter sw = File.CreateText(path))
        {
            foreach (Player player in currentRankings)
            {
                sw.WriteLine($"{player.Name}|{player.Score}");
            }
        }

        UI.WriteLine("Your score has been registered! :D", 2, 20);
    }

    // Muestra las mejores puntuaciones
    public void ShowTopRankings()
    {
        List<Player> currentRankings = GetTopRankings();
                    
        Console.WriteLine();
        UI.WriteLine("CURRENT TOP ROBORULE RANKS:", 2, 30);
        Console.WriteLine();

        if (currentRankings.Count >= 1)
            UI.WriteLine($"USERNAME: {currentRankings[0].Name} | SCORE: {currentRankings[0].Score}", 1, 30);
        else
            UI.WriteLine($"USERNAME: - | SCORE: -", 1, 30);
        
        if (currentRankings.Count >= 2)
            UI.WriteLine($"USERNAME: {currentRankings[1].Name} | SCORE: {currentRankings[1].Score}", 7, 30);
        else
            UI.WriteLine($"USERNAME: - | SCORE: -", 7, 30);
        
        if (currentRankings.Count >= 3)
            UI.WriteLine($"USERNAME: {currentRankings[2].Name} | SCORE: {currentRankings[2].Score}", 5, 30);
        else
            UI.WriteLine($"USERNAME: - | SCORE: -", 5, 30);
    }

    // Recoge las mejores puntuaciones
    public List<Player> GetTopRankings()
    {
        var rankings = new List<Player>();
        
        using (StreamReader sr = File.OpenText(path))
        {
            string rank;

            while ((rank = sr.ReadLine()!) != null)
            {
                string[] rankInfo = rank.Split("|");
                string name = rankInfo[0];
                int score = int.Parse(rankInfo[1]);
                
                Player player = new Player(name, score);
                rankings.Add(player);
            }
        }

        return rankings;
    }
}