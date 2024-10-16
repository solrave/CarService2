namespace CarService2;

public class ReplaceWheelJob : JobParentClass
{
    
    public ReplaceWheelJob()
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
            typeOfJob = "Wheel";
            message = "WHEEL replaced successfully!";
            done = true;
            //reward
        }
        else
        {
            typeOfJob = "Wheel";
            message = "WRONG part replaced!";
            done = false;
            //penalty
        }
        return (typeOfJob,message, done);
    }
}