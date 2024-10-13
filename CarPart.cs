namespace CarService2;

public class CarPart
{
    private readonly string _name;
    private readonly bool _isBroken;
    public bool IsBroken { get; protected init; }
    public string Name { get; protected init; }
    protected CarPart()
    {
       
    }
    
    public CarPart(string name, bool isBroken)
    {
        Name = name;
        IsBroken = isBroken;
    }
    

    public override string ToString()
    {
        return $"Part name: {Name}, Broken: {IsBroken} ";
    }
}