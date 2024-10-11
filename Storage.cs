using static System.Console;

namespace CarService2;

public class Storage : IListAsMenu
{
    private readonly List<CarPart> _stock;
    public Storage()
    {
        _stock = new List<CarPart>()
        {
            { new CarPart("Wheel", false)},
            { new CarPart("Wheel", false)},
            { new CarPart("Wheel", false)},
            { new CarPart("Wheel", false)},
            { new CarPart("Wheel", false)},
            { new CarPart("Wheel", false)},
            { new CarPart("Engine Oil", false)},
            { new CarPart("Wheel", false)}
        };
    }
    
    public List<CarPart> Stock
    {
        get => _stock;
    }

    public CarPart GetPartFromStorage(int part)
    {
        CarPart temp = Stock[part];
        Stock.RemoveAt(part);
        return temp;
    }

    public int GetStorageQuantity()
    {
        return _stock.Count;
    }

    public int GetPartQuantity(string name)
    {
        var counter = 0;
        foreach (var part in _stock)
            if (part.Name == name)
                counter += 1;

        return counter;
    }
    public override string ToString()
    {
        return base.ToString();
    }
}