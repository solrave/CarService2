using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CarService2;

public class Car : IMoneyUser, IListAsMenu
{
    private readonly string _carBrand;
    private List<CarPart> _carEquipment;
    private int _money;

    public string CarBrand { get; }
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
        _carEquipment = new List<CarPart>(5);
        _carEquipment.Add(new CarPart("Wheel"));
        _carEquipment.Add(new CarPart("Wheel"));
        _carEquipment.Add(new CarPart("Wheel"));
        _carEquipment.Add(new CarPart("Wheel"));
        _carEquipment.Add(new CarPart("Engine Oil"));
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
        var sb = new StringBuilder($"Brand:{_carBrand}\n Money:{_money}\n");
        //foreach (var part in _carEquipment) sb.Append($"{part}\n");
        return sb.ToString();
    }
    
}