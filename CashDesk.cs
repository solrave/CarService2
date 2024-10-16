namespace CarService2;

public class CashDesk : IMoneyUser
{
    private readonly Dictionary<CarPart, int> _partPrices;
    private readonly Dictionary<string, int> _jobPrices;
    private int totalPrice = 0;
    private int partPrice = 0;
    private int jobPrice = 0;

    public CashDesk()
    {
        Money = 1000;
        _partPrices = new Dictionary<CarPart, int>()
        {
            { new Wheel("Pirelli", false), 50 },
            { new EngineOil("Motul", false), 20 }
        };
        _jobPrices = new Dictionary<string, int>()
        {
            { "Wheel", 100 },
            { "Oil", 40 }
        };
    }

    public int Money { get; set; }
    public Dictionary<CarPart,string> PartPrices { get; }
    public Dictionary<string, int> JobPrices { get; }

    public void CalculateRepairCost(CarPart carPart, string typeOfJob)
    {
        foreach (var part in _partPrices)
        {
            if (carPart.GetType() == part.Key.GetType())
            {
                partPrice = part.Value;
            }
        }
        foreach (var job in _jobPrices)
        {
            if (typeOfJob == job.Key)
            {
                jobPrice = job.Value;
            }
        }
        totalPrice = partPrice + jobPrice;
    }

    public static void CalculatePenaltyCost()
    {
        //(partPrice + workPrice) * 2 => penalty
    }
    
    public void MakeTransaction(IMoneyUser sender, IMoneyUser receiver)
    {
        sender.Money -= totalPrice;
        receiver.Money += totalPrice;
    }
}