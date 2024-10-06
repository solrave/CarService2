namespace CarService2;

public interface IPerformJob
{
    bool PerformJob(Car car, Storage storage);
}