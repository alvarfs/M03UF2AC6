using System.Linq;

class Rankings
{
    public string path = @".\TopRankings.txt";

    // Guarda la puntuación del jugador
    public void SaveRanking(Player mainPlayer)
    {
        // Recoger las puntuaciones guardadas y del jugador para compararlas
        List<Player> currentRankings = GetTopRankings();
        currentRankings.Add(mainPlayer);

        // Los ordenamos en base a su puntuación, y recogemos los 3 mejores
        currentRankings.OrderByDescending(rank => rank.Score).Take(3);

        using (StreamWriter sw = File.CreateText(path))
        {
            foreach (Player player in currentRankings)
            {
                sw.WriteLine($"{player.Name}|{player.Score}");
            }
        }
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