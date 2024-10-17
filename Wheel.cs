namespace CarService2;

public class Wheel : CarPart
{
    private readonly string[] _wheelNames = { "Pirelli", "GoodYear", "Sprinter"};
    public Wheel()
    {
        Random random = new Random();
        Name = _wheelNames[random.Next(0, _wheelNames.Length)];
        if (random.Next(0, 11) % 2 == 0)
        {
            IsBroken = true;
        }
    }
    public Wheel(string name, bool isBroken) : base(name, isBroken)
    {
        
    }
    public override string ToString()
    {
        return $"Part name: {Name}, Broken: {IsBroken} ";
    }
    
}