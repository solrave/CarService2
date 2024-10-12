namespace CarService2;
using static System.Console;
public class CarService : IMoneyUser
{
    private int _money;
    private Storage _stock;
    private MarketGenerator _clients;
    private ReplaceWheelJob _job;
    public CarService(int money, MarketGenerator clients, ReplaceWheelJob job)
    {
        _money = money;
        _stock = new Storage();
        _clients = clients;
        _job = job;
    }

    public Storage Storage => _stock;
    public MarketGenerator Clients => _clients;

    public ReplaceWheelJob Job => _job;
    
    public int Money
    {
        get => _money;
        set => _money = value;
    }
}