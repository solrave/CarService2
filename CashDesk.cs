namespace CarService2;

public class CashDesk : IMoneyUser
{
    private readonly Dictionary<CarPart, int> _partPrices;
    private readonly Dictionary<JobParentClass, int> _jobPrices;

    public CashDesk()
    {
        _partPrices = new Dictionary<CarPart, int>()
        {
            { new Wheel("Pirelli", false), 50 },
            { new EngineOil("Motul", false), 20 }
        };
        _jobPrices = new Dictionary<JobParentClass, int>()
        {
            { new ReplaceWheelJob(), 100 },
            { new ReplaceOilJob(), 40 }
        };
    }

    public int Money { get; set; }
    public Dictionary<CarPart,string> PartPrices { get; }
    public Dictionary<JobParentClass, int> JobPrices { get; }

    public static void CalculateRepairCost()
    {
       // int totalPrice, partPrice, jobPrice;
        

       // return totalPrice;
    }
    
    public void MakeTransaction(IMoneyUser sender, IMoneyUser receiver)
    {
        
    }
}