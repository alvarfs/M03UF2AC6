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
        hashCollection.ConsultRobots();
        dolarCollection.ConsultRobots();
        sevenCollection.ConsultRobots();
    }

    // Recuento de puntuación en base a cada robots en cada colección
    public int CurrentRobotScore()
    {
        int currentScore = 0;

        foreach (Seven robot in sevenCollection.robots)
            currentScore += 3;

        foreach (Dolar robot in dolarCollection.robots)
            currentScore += 2;
        
        foreach (Hash robot in hashCollection.robots)
            currentScore += 1;
        
        return currentScore;
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