using static System.Console;

namespace CarService2;

public class MarketGenerator//Здесь создаётся список поломанных машин для передачи его в Автосервис.
{
    private List<Car> _clients;

    public List<Car> Clients
    {
        get => _clients;
        set => _clients = value;
    }

    public MarketGenerator()
    {
        CreateSomeCars();
    }

    private void CreateSomeCars()
    {
        _clients = new List<Car>(4);
        for (var i = 0; i < _clients.Capacity; i++) _clients.Add(new Car());
    }
    
    public void ShowClientQueue()
    {
        foreach (var car in _clients) WriteLine(car);
    }
}