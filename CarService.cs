namespace CarService2;

public class CarService : IMoneyUser
{
    private int _money;
    private Storage _stock;
    private List<Car> _clients;
    private List<IPerformJob> _jobs;
    
    public int Money
    {
        get => _money;
        set => _money = value;
    }

    public List<IPerformJob> Jobs { get; }

    public CarService(int money)
    {
        _money = money;
        _stock = new Storage();
        _jobs = new List<IPerformJob>()
        {
            {new ReplacePartJob("Wheel")},
            {new ReplacePartJob("Engine Oil")}
        };
    }

    public void TransferMoneyTo(IMoneyUser receiver, int amount)
    {
        
    }

    public void GetClientCars(MarketGenerator street)
    {
        _clients = street.Clients;
    }
}