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
            {new CarPart("Wheel", false), 50},
            {new CarPart("Engine Oil", false), 20}
        };
        _jobPrices = new()
        {
            {new ReplacePartJob("Wheel"), 25},
            {new ReplacePartJob("Engine Oil"), 10}
        };
    }

    public void CalculateRepairCost()
    {
        
    }
    
    public void MakeTransaction(IMoneyUser sender, IMoneyUser receiver, ReplacePartJob job)
    {
        
    }
}