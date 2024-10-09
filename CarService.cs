namespace CarService2;

public class CarService : IMoneyUser
{
    private int _money;
    private Storage _stock;
    private List<Car> _clients;
    public int Money
    {
        get => _money;
        set => _money = value;
    }
    public CarService(int money)
    {
        _money = money;
        _stock = new Storage();
    }
    public void PerformJob(Car car,int part,Storage storage, int partFromStorage)
    {
        car.CarEquipment.RemoveAt(part);
        car.CarEquipment.Insert(part,storage.GetPartFromStorage(partFromStorage));
    }

    public void GetClientCars(MarketGenerator street)
    {
        _clients = street.Clients;
    }
}