namespace CarService2;

public class ReplaceWheelJob : JobParentClass
{
    
    public ReplaceWheelJob()
    {
     
    }
    
    public override string PerformJob(Car car, CarPart carPart, CarPart partFromStorage)
    {
        string message;
        car.CarEquipment.Remove(carPart);
        car.CarEquipment.Add(partFromStorage); 
        if (carPart.IsBroken && carPart.GetType() == partFromStorage.GetType())
        {
            message = "WHEEL replaced successfully!"; 
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