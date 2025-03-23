class Seven : Hash
{
    public float Version { get; set; }
    public Seven(int id, string model) : base(id, model)
    {
        Random random = new Random();
        Version = random.Next(1, 91);
    }

    // Muestra los detalles
    public override string ToString()
    {
        return $"{Model}-{Id}: Date {Date} | Robots Repaired: {NumberOfRepairs()} | Flights taken: {NumberOfFlights()}";
    }

    // Indica cuantos vuelos ha realizado
    public int NumberOfFlights()
    {
        Random random = new Random();
        return random.Next(10, 21);
    }
}