namespace CarService2;

public class JobParentClass
{
    private CarPart _carPart, _storagePart;
    private MarketGenerator _clients;
    private Storage _storage;
    private CashDesk _cashDesk;

    public JobParentClass(MarketGenerator clients, Storage storage, CashDesk cashDesk)
    {
        _clients = clients;
        _storage = storage;
        _cashDesk = cashDesk;
    }

    public MarketGenerator Clients => _clients;
    public Storage Storage => _storage;
    public CashDesk CashDesk => _cashDesk;

    public virtual string PerformJob(Car car, CarPart carPart, CarPart PartFromStorage)
    {
        string message;
        car.CarEquipment.Remove(carPart);
        car.CarEquipment.Add(PartFromStorage);
        if (carPart.Name == PartFromStorage.Name && carPart.IsBrokenStat)
        {
            message = "Part replaced successfully!";
        }
        else
        {
            message = "You replaced a wrong part!";
        }
        return message;
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