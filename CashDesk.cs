namespace CarService2;

public class CashDesk : IMoneyUser
{
    private int _money;
    private readonly Dictionary<string, int> _partPrices;
    private readonly Dictionary<string, int> _jobPrices;

    public CashDesk()
    {
        _partPrices = new Dictionary<string, int>()
        {
            { "Wheel", 50 },
            { "Engine Oil", 20 }
        };
    }

    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
        }
    }
    public void CalculateRepairCost()
    {
        int price = 0;
    }
    
    public void MakeTransaction(IMoneyUser sender, IMoneyUser receiver)
    {
        
    }
}