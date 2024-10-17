namespace CarService2;

public class EngineOil : CarPart
{
   private string[] _oilNames = { "Motul", "Shell", "Rider", "Lava" };
    
    public EngineOil()
    {
        Random random = new Random();
        Name = _oilNames[random.Next(0, _oilNames.Length)];
        if (random.Next(0, 11) % 2 == 0)
        {
            IsBroken = true;
        }
    }
    public EngineOil(string name, bool isBroken) : base(name, isBroken)
    {
        
    }
    public override string ToString()
    {
        return $"Part name: {Name}, Broken: {IsBroken} ";
    }
}