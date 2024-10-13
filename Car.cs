using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace CarService2;

public class Car : IMoneyUser
{
    public string CarBrand { get; }

    public List<CarPart> CarEquipment { get; }

    public int Money { get; set; }

    public Car()
    {
        Money = 500;
        CarBrand = AssignRandomCarBrand(); //Назначается случайная марка авто.
        CarEquipment = new List<CarPart>
        {
            new Wheel(), //создаются запчасти со случайным именем и поломкой
            new Wheel(),
            new Wheel(),
            new Wheel(),
            new EngineOil()
        };
    }

    private string AssignRandomCarBrand() //Назначается случайная марка авто из списка
    {
        string[] brandNames = { "Ferrari", "BMW", "Opel", "Dacia", "Ford", "Reno", "Bentley" };
        var random = new Random();
        return brandNames[random.Next(0, brandNames.Length)];
    }
    
    public void TransferMoneyTo(IMoneyUser receiver, int amount)
    {
        
    }

    public override string ToString()
    {
        var sb = new StringBuilder($"Brand:{CarBrand} Money:{Money}");
        //foreach (var part in _carEquipment) sb.Append($"{part}\n");
        return sb.ToString();
    }
}