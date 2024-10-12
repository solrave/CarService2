namespace CarService2;

public class ReplaceWheelJob : JobParentClass
{
    public ReplaceWheelJob(MarketGenerator clients, Storage storage, CashDesk cashDesk) : base (clients, storage, cashDesk)
    {
        
    }

    public override string PerformJob(Car car, CarPart carPart, CarPart PartFromStorage)
    {
        string message;
        car.CarEquipment.Remove(carPart);
        car.CarEquipment.Add(PartFromStorage); 
        if (carPart.Name == "Wheel" && carPart.Name == PartFromStorage.Name && carPart.IsBrokenStat)
        {
            message = "Part replaced successfully!";
            //reward logic PartPrice == WheelPrice, JobPrice == WheelReplacementPrice
        }
        else
        {
            message = "You replaced a wrong part!";
            //penalty logic
        }
        return message;
    }
}