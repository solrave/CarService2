namespace CarService2;
using static System.Console;
public class Mechanic
{
    public ReplaceWheelJob WheelJob { get; }
    
    public ReplaceOilJob OilJob { get; }
    
    public Car Car { get; set; }
    public CarPart CarPart { get; set; }
    public CarPart PartFromStorage { get; set; }
    
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
            WriteLine(WheelJob.PerformJob(Car, CarPart, PartFromStorage));
        }
        else if (CarPart.GetType() == typeof(EngineOil))
        {
            WriteLine(OilJob.PerformJob(Car,CarPart,PartFromStorage));
        }
    }
}