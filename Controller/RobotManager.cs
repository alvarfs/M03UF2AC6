using System.Linq;

class RobotManager
{
    public RobotCollection<Hash> hashCollection;
    public RobotCollection<Dolar> dolarCollection;
    public RobotCollection<Seven> sevenCollection;

    public RobotManager()
    {
        hashCollection = new RobotCollection<Hash>();
        dolarCollection = new RobotCollection<Dolar>();
        sevenCollection = new RobotCollection<Seven>();
    }
    
    // Muestra la información especifica de cada robot de cada colección
    public void ShowRobotCollections()
    {
        Console.Clear();
        
        UI.WriteLine("HASH ROBOTS:", 0, 10);
        hashCollection.ConsultRobots();

        UI.WriteLine("DOLAR ROBOTS:", 1, 10);
        dolarCollection.ConsultRobots();

        UI.WriteLine("SEVEN ROBOTS:", 2, 10);
        sevenCollection.ConsultRobots();
    }

    // Recuento de puntuación en base a cada robots en cada colección
    public int CurrentRobotScore()
    {
        int currentScore = 0;
        
        currentScore += sevenCollection.robots.Sum(robot => 3);
        currentScore += dolarCollection.robots.Sum(robot => 2);
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
                        UI.WriteLine("HASH ROBOT CREATED!", 0, 15);
                        break;

                    case 1:
                        Dolar dolarRobot = new Dolar(0, $"V.{random.Next(0, 100)}");
                        AddNewDolar(dolarRobot);
                        UI.WriteLine("DOLAR ROBOT CREATED!", 1, 15);
                        break;

                    case 2:
                        Seven sevenRobot = new Seven(0, $"V.{random.Next(0, 100)}");
                        AddNewSeven(sevenRobot);
                        UI.WriteLine("SEVEN ROBOT CREATED!", 2, 15);
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

    // Añadimos un nuevo Dolar a su colección
    public void AddNewDolar(Dolar robot)
    {
        robot.Id = dolarCollection.idIndex;
        dolarCollection.InsertRobot(robot);
    }

    // Añadimos un nuevo Hash a su colección
    public void AddNewHash(Hash robot)
    {
        robot.Id = hashCollection.idIndex;
        hashCollection.InsertRobot(robot);
    }
}