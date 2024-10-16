namespace CarService2;

public class ReplaceOilJob : JobParentClass
{
    public ReplaceOilJob()
    {
        
    }
    
    public override (string,string,bool) PerformJob(Car car, CarPart carPart, CarPart partFromStorage)
    {
        string typeOfJob;
        string message;
        bool done;
        car.CarEquipment.Remove(carPart);
        car.CarEquipment.Add(partFromStorage); 
        if (carPart.IsBroken && carPart.GetType() == partFromStorage.GetType())
        {
            typeOfJob = "Oil";
            done = true;
            message = "OIL replaced successfully!";
            //reward
        }
        else
        {
            typeOfJob = "Oil";
            done = false;
            message = "WRONG part replaced!";
            //penalty
        }
        return (typeOfJob, message, done);
    }
    
}