namespace CarService2;
using static System.Console;
public class Mechanic
{
    public ReplaceWheelJob WheelJob { get; }
    public ReplaceOilJob OilJob { get; }
    public Car Car { get; set; }
    public CarPart CarPart { get; set; }
    public CarPart PartFromStorage { get; set; }
    public (string,string, bool) Result { get; set; }
    public Mechanic()
    {
        WheelJob = new ReplaceWheelJob();
        OilJob = new ReplaceOilJob();
    }
    public void StartService(Car car, CarPart carPart, CarPart partFromStorage)
    {
        Car = car;
        CarPart = carPart;
        PartFromStorage = partFromStorage;
        PerformAppropriateJob();
    }
    private void PerformAppropriateJob()
    {
        if (CarPart.GetType() == typeof(Wheel))
        {
           Result = WheelJob.PerformJob(Car, CarPart, PartFromStorage);
           WriteLine(Result.Item1);
        }
        else if (CarPart.GetType() == typeof(EngineOil))
        {
           Result = OilJob.PerformJob(Car,CarPart,PartFromStorage);
           WriteLine(Result.Item1);
        }
    }
    public string GetJobType()
    {
        return Result.Item1;
    }
    public void GetJobMessage()
    {
        WriteLine(Result.Item2);
    }
    public bool GetJobResult()
    {
        return Result.Item3;
    }
}