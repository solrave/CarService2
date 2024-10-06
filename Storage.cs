using static System.Console;

namespace CarService2;

public class Storage : IListAsMenu
{
    private readonly List<CarPart> _stock;

    public List<CarPart> Stock
    {
        get => _stock;
    }
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

    public CarPart GetPartFromStorage(string name)
    {
        CarPart temp = new CarPart("Wheel");
        for (int i = 0; i < _stock.Count; i++)
        {
            if (_stock[i].Name == name)
            {
                temp = _stock[i];
                _stock.RemoveAt(i);
            }
        }

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

    public void ShowStorage()
    {
        WriteLine("Part/Price:");
        foreach (var part in _stock) WriteLine($"{part}, Pcs: {GetPartQuantity(part.Name)}");
        WriteLine($"Total pcs: {GetStorageQuantity()}");
    }
}