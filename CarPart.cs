namespace CarService2;

public class CarPart : IListAsMenu

{
    private readonly string _name;
    private readonly bool _isBroken;

    public CarPart(string name, bool isBroken)
    {
        _name = name;
        _isBroken = isBroken;
    }
    public CarPart(string name)
    {
        _name = name;
        Random randomizeBreak = new Random();
        if (randomizeBreak.Next(0,11)%2 == 0)
        {
            _isBroken = true;
        }
    }

    public bool IsBrokenStat
    {
        get { return _isBroken; }
    }
    
    public string Name
    {
        get => _name;
    }

    public override string ToString()
    {
        return $"Part name: {Name}, Broken: {IsBrokenStat} ";
    }
}