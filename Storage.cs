using static System.Console;

namespace CarService2;

public class Storage
{
    public List<CarPart> Stock => _stock;
    private readonly List<CarPart> _stock;

    public Storage()
    {
        _stock = new List<CarPart>()
        {
            { new Wheel("Pirelli", false) },
            { new Wheel("Pirelli", false) },
            { new Wheel("GoodYear", false) },
            { new Wheel("GoodYear", false) },
            { new Wheel("GoodYear", false) },
            { new Wheel("GoodYear", false) },
            { new EngineOil("Motul", false) },
            { new Wheel("Pirelli", false) }
        };
    }
}
