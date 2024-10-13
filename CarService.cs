namespace CarService2;
using static System.Console;
public class CarService : IMoneyUser
{
    public CarService(int money, MarketGenerator clients, ReplaceWheelJob wheelJob, ReplaceOilJob oilJob, CashDesk cashDesk)
    {
        Money = money;
        Storage = new Storage();
        Clients = clients;
        WheelJob = wheelJob;
        OilJob = oilJob;
        CashDesk = cashDesk;
    }

    public Storage Storage { get; }

    public MarketGenerator Clients { get; }

    public ReplaceWheelJob WheelJob { get; }
    
    public ReplaceOilJob OilJob { get; }
    
    public CashDesk CashDesk { get; }

    public int Money { get; set; }
}