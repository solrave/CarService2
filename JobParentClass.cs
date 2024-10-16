namespace CarService2;

public class JobParentClass
{
    protected JobParentClass()
    {
    }
    public virtual (string, string,bool) PerformJob(Car car, CarPart carPart, CarPart partFromStorage)
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
        return (typeOfJob,message, done);
        }

    #region OldMethodPerformJob
    /*public virtual string PerformJob(int car,int part, int partFromStorage)
       {
           string message;
           if (_clients.Clients[car].CarEquipment[part].IsBrokenStat && _clients.Clients[car].CarEquipment[part].Name == _storage.Stock[partFromStorage].Name)
           {
               _clients.Clients[car].CarEquipment.RemoveAt(part);
               _clients.Clients[car].CarEquipment.Add(_storage.Stock[partFromStorage]);
               message = "Part was replaced successfully!";
               //get reward
           }
           else
           {
               message = "You replaced a wrong part!";
               //penalty
           }

           return message;
       }*/
    

    #endregion
   

}