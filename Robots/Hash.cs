class Hash : Robot
{
    public Hash(int id, string model) : base(id, model){}
    

    // Muestra los detalles
    public override string ToString()
    {
        return $"{Model}-{Id}: Date {Date} | Robots Repaired: {NumberOfRepairs()}";
    }

    // Indica cuantos robots ha reparado
    public int NumberOfRepairs()
    {
        Random random = new Random();
        return random.Next(0, 11);
    }
}