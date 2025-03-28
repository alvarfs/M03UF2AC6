class Robot
{
    public int Id { get; set; }
    public string Model { get; set; }
    public DateTime Date { get; set; }
    public Robot(int id, string model)
    {
        Id = id;
        Model = model;
        Date = DateTime.Now;
    }
    
    // Muestra los detalles del robot
    public override string ToString()
    {
        return $"MODEL: {Model}-{Id}: Date {Date}";
    }
}