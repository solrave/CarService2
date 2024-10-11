namespace CarService2;

public class CashDesk
{
    private int _money;
    private readonly Dictionary<CarPart, int> _partPrices;
    private readonly Dictionary<IPerformJob, int> _jobPrices;

    public CashDesk()
    {
        _partPrices = new()
        {
            { new CarPart("Wheel", false), 50 },
            { new CarPart("Engine Oil", false), 20 }
        };
    }

    public void CalculateRepairCost()
    {
        int price = 0;
    }
    
    public void MakeTransaction(IMoneyUser sender, IMoneyUser receiver)
    {
        
    }
}