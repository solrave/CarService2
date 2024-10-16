namespace CarService2;
using static System.Console;
public class CarService
{
    public CarService()
    {
        Storage = new Storage();
        Clients = new MarketGenerator();
        CashDesk = new CashDesk();
        Vitya = new Mechanic();
    }
    public Mechanic Vitya { get; set; }
    public Storage Storage { get; }
    public MarketGenerator Clients { get; }
    public CashDesk CashDesk { get; }
}