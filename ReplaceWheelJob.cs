namespace CarService2;

public class ReplaceWheelJob : JobParentClass
{
    private string _name;
    public ReplaceWheelJob()
    {
        _name = "Wheel Replacement";
    }

    public string Name { get; }

    public override string PerformJob(Car car, CarPart carPart, CarPart PartFromStorage)
    {
        string message;
        car.CarEquipment.Remove(carPart);
        car.CarEquipment.Add(PartFromStorage); 
        if (carPart.Name == "Wheel" && carPart.Name == PartFromStorage.Name && carPart.IsBroken)
        {
            message = "Part replaced successfully!";
            //reward logic PartPrice == WheelPrice, JobPrice == WheelReplacementPrice
            car.Money -= 150;
        }
        else
        {
            message = "You replaced a wrong part!";
            //penalty logic
        }
        return message;
    }
}