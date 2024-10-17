namespace CarService2;

public class JobParentClass
{
    protected JobParentClass()
    {
    }

    public virtual (string, string, bool) PerformJob(Car car, CarPart carPart, CarPart partFromStorage)
    {
        string typeOfJob;
        string message;
        bool done;
        car.CarEquipment.Remove(carPart);
        car.CarEquipment.Add(partFromStorage);
        if (carPart.Name == partFromStorage.Name && carPart.IsBroken)
        {
            typeOfJob = "Part Replacement";
            message = "Part replaced successfully!";
            done = true;
        }
        else
        {
            typeOfJob = "Part Replacement";
            message = "You replaced a wrong part!";
            done = false;
        }

        return (typeOfJob, message, done);
    }
}