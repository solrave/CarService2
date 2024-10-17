namespace CarService2;

public class CashDesk : IMoneyUser
{
    public int Money { get; set; }
    public Dictionary<CarPart,string> PartPrices { get; }
    public Dictionary<string, int> JobPrices { get; }
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
    public void CalculateRepairCost(CarPart carPart, string typeOfJob)
    {
        GetPartPrice(carPart);
        GetJobPrice(typeOfJob);
        totalPrice = partPrice + jobPrice;
    }
    private void GetJobPrice(string typeOfJob)
    {
        foreach (var job in _jobPrices)
        {
            if (typeOfJob == job.Key)
            {
                jobPrice = job.Value;
            }
        }
    }
    private void GetPartPrice(CarPart carPart)
    {
        foreach (var part in _partPrices)
        {
            if (carPart.GetType() == part.Key.GetType())
            {
                partPrice = part.Value;
            }
        }
    }
    public void CalculatePenaltyCost(CarPart carPart, string typeOfJob)
    {
        GetPartPrice(carPart);
        GetJobPrice(typeOfJob);
        totalPrice = (partPrice + jobPrice)* 2;
    }
    public void MakeTransaction(IMoneyUser sender, IMoneyUser receiver)
    {
        sender.Money -= totalPrice;
        receiver.Money += totalPrice;
    }
    public void ApplyPenalty()
    {
        Money -= totalPrice;
    }
}