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
}