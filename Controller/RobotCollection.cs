class RobotCollection<T>
{
    public List<T> robots;
    public int idIndex = 1;

    public RobotCollection()
    {
        robots = new List<T>();
    }

    // Insertamos el nuevo robot en la colección
    public void InsertRobot(T robot)
    {
        robots.Add(robot);
        idIndex++;
    }

    // Consultamos la información de cada robot dentro de la colección
    public void ConsultRobots()
    {
        foreach (T robot in robots)
        {
            UI.WriteLine($"{robot.ToString()}", 3, 2);
        }
        Console.WriteLine();
    }
}