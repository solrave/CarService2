using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CarService2;

public class Car : IMoneyUser
{
    private readonly string _carBrand;
    private List<CarPart> _carEquipment;
    private int _money;

    public string CarBrand
    {
        get { return _carBrand; }

    }
    public List<CarPart> CarEquipment
    {
        get => _carEquipment;
        set => _carEquipment = value;
    }
    
    public int Money
    {
        get => _money;
        set => _money = value;
    }
    public Car()
    {
        _money = 500;
        _carBrand = AssignRandomCarBrand(); //Назначается случайная марка авто.
        _carEquipment = new List<CarPart>();
        _carEquipment.Add(new Wheel("Wheel"));
        _carEquipment.Add(new Wheel("Wheel"));
        _carEquipment.Add(new Wheel("Wheel"));
        _carEquipment.Add(new Wheel("Wheel"));
        _carEquipment.Add(new EngineOil("Engine Oil"));
    }

    private string AssignRandomCarBrand() //Назначается случайная марка авто.
    {
        string[] brandNames = { "Ferrari", "BMW", "Opel", "Dacia", "Ford", "Reno", "Bentley" };
        var random = new Random();
        var randomName = random.Next(0, brandNames.Length);
        return brandNames[randomName];
    }
    
    public void TransferMoneyTo(IMoneyUser receiver, int amount)
    {
        
    }

    public override string ToString()
    {
        var sb = new StringBuilder($"Brand:{_carBrand} Money:{_money}");
        //foreach (var part in _carEquipment) sb.Append($"{part}\n");
        return sb.ToString();
    }
}