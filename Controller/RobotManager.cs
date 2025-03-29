using System.Linq;

class RobotManager
{
    public RobotCollection<Hash> hashCollection;
    public RobotCollection<Dollar> dollarCollection;
    public RobotCollection<Seven> sevenCollection;

    public RobotManager()
    {
        hashCollection = new RobotCollection<Hash>();
        dollarCollection = new RobotCollection<Dollar>();
        sevenCollection = new RobotCollection<Seven>();
    }
    
    // Muestra la información especifica de cada robot de cada colección
    public void ShowRobotCollections()
    {
        Console.Clear();
        
        UI.WriteLine("# ROBOTS:", 0, 10);
        hashCollection.ConsultRobots();

        UI.WriteLine("$ ROBOTS:", 1, 10);
        dollarCollection.ConsultRobots();

        UI.WriteLine("7 ROBOTS:", 2, 10);
        sevenCollection.ConsultRobots();
    }

    // Recuento de puntuación en base a cada robots en cada colección
    public int CurrentRobotScore()
    {
        int currentScore = 0;
        
        currentScore += sevenCollection.robots.Sum(robot => 3);
        currentScore += dollarCollection.robots.Sum(robot => 2);
        currentScore += hashCollection.robots.Sum(robot => 1);
        
        return currentScore;
    }

    // Genera robots en base a los resultados de la ruleta
    public void GenerateRobots(List<int[]> result)
    {
        Random random = new Random();
        
        // Por cada combinación
        foreach (int[] roll in result)
        {
            // Por cada slot de cada combinación
            foreach (int slot in roll)
            {
                switch (slot)
                {
                    case 0:
                        Hash hashRobot = new Hash(0, $"V.{random.Next(0, 100)}");
                        AddNewHash(hashRobot);
                        UI.WriteLine("NEW ROBOT # GENERATED!", 0, 15);
                        break;

                    case 1:
                        Dollar dollarRobot = new Dollar(0, $"V.{random.Next(0, 100)}");
                        AddNewDollar(dollarRobot);
                        UI.WriteLine("NEW ROBOT $ GENERATED!", 1, 15);
                        break;

                    case 2:
                        Seven sevenRobot = new Seven(0, $"V.{random.Next(0, 100)}");
                        AddNewSeven(sevenRobot);
                        UI.WriteLine("NEW ROBOT 7 GENERATED!", 2, 15);
                        break;

                    default:
                        break;
                }
            }
        }

        Console.WriteLine();
    }

    // Añadimos un nuevo Seven a su colección
    public void AddNewSeven(Seven robot)
    {
        robot.Id = sevenCollection.idIndex;
        sevenCollection.InsertRobot(robot);
    }

    // Añadimos un nuevo dollar a su colección
    public void AddNewDollar(Dollar robot)
    {
        robot.Id = dollarCollection.idIndex;
        dollarCollection.InsertRobot(robot);
    }

    // Añadimos un nuevo Hash a su colección
    public void AddNewHash(Hash robot)
    {
        robot.Id = hashCollection.idIndex;
        hashCollection.InsertRobot(robot);
    }
}