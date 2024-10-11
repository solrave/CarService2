namespace CarService2;
using static System.Console;
public class CarService : IMoneyUser
{
    private int _money;
    private Storage _stock;
    private MarketGenerator _clients;
    public CarService(int money, MarketGenerator clients)
    {
        _money = money;
        _stock = new Storage();
        _clients = clients;
    }

    public Storage Storage => _stock;
    public MarketGenerator Clients => _clients;
    
    public int Money
    {
        get => _money;
        set => _money = value;
    }
    public string PerformJob(int car,int part, int partFromStorage)
    {
        string message;
        if (!_clients.Clients[car].CarEquipment[part].IsBrokenStat && _clients.Clients[car].CarEquipment[part].Name == Storage.Stock[partFromStorage].Name)
        {
            _clients.Clients[car].CarEquipment.RemoveAt(part);
            _clients.Clients[car].CarEquipment.Add(Storage.Stock[partFromStorage]);
            message = "Part was replaced successfully!";
        }
        else
        {
            message = "You replaced a wrong part!";
        }

        return message;
    }

}