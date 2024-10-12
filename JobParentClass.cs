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

    public virtual string PerformJob(int car,int part, int partFromStorage)
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
    }

}