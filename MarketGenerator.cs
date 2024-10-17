using static System.Console;

namespace CarService2;

public class MarketGenerator//Здесь создаётся список поломанных машин для передачи его в Автосервис.
{
    public List<Car> Clients { get; private set; }
    public MarketGenerator()
    {
        CreateSomeCars();
    }
    private void CreateSomeCars() //создать пять машин
    {
        Clients = new List<Car>();
        for (var i = 0; i < 5; i++) Clients.Add(new Car());
    }
}