namespace CarService2;

public class ReplaceOilJob : JobParentClass
{
    public ReplaceOilJob()
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
            //reward logic OIL!!!!!!!
        }
        else
        {
            message = "You replaced a wrong part!";
            //penalty logic OIL!!!!!!
        }
        return message;
    }
    
}