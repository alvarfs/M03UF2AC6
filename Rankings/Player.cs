public class Player
{
    public string Name { get; set; }
    public int Score { get; set; }
    public int Coins { get; set; }
    public int RobotScore { get; set; }
    public int ExtraScore { get; set; }

    public Player (string name, int score)
    {
        Name = name;
        Score = score;
        Coins = 10;
        RobotScore = 0;
        ExtraScore = 0;
    }

    // Guarda la nueva puntuación del jugador
    public void SetNewScore()
    {
        Score = RobotScore + ExtraScore;
    }

    public void ShowCurrentScore()
    {
        Console.Clear();

        UI.WriteLine($"ROBOT POINTS: {RobotScore}", 3, 30);
        UI.WriteLine($"EXTRA POINTS: {ExtraScore}", 1, 30);
        UI.WriteLine($"TOTAL SCORE: {Score}", 2, 30);
    }
}