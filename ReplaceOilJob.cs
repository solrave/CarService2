namespace CarService2;

public class ReplaceOilJob : JobParentClass
{
    public ReplaceOilJob()
    {
        
    }
    
    public override string PerformJob(Car car, CarPart carPart, CarPart partFromStorage)
    {
        string message;
        car.CarEquipment.Remove(carPart);
        car.CarEquipment.Add(partFromStorage); 
        if (carPart.IsBroken && carPart.GetType() == partFromStorage.GetType())
        {
            message = "OIL replaced successfully!"; 
            //reward
        }
        else
        {
            message = "WRONG part replaced!";
            //penalty
        }
        return message;
    }
    
}