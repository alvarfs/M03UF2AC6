class Dollar : Robot
{
    public Dollar(int id, string model) : base(id, model){}
    
    // Muestra los detalles
    public override string ToString()
    {
        return $"MODEL: {Model}-{Id}: Date {Date} | Robots Defeated: {NumberOfBattles()}";
    }

    // Indica cuantos combates ha realizado
    public int NumberOfBattles()
    {
        Random random = new Random();
        return random.Next(0, 11);
    }
}