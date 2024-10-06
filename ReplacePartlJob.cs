namespace CarService2;
using static System.Console;

public class ReplacePartJob : IPerformJob
{
    private readonly string _partName;
    
    public ReplacePartJob(string name)
    {
        _partName = name;
    }
    
    
    
    public bool PerformJob(Car car, Storage storage) //bool??
    {
        foreach (var part in car.CarEquipment)
        {
            if (part.IsBrokenStat == true && part.Name == _partName)
            {
                car.CarEquipment.Remove(part);
                car.CarEquipment.Add(storage.GetPartFromStorage(_partName));
                //replaceCounter++; Calculate overall cost?
            }
            else
            {
                WriteLine("You chose the wrong part!");
                //penalty!!
                return false;
            }
        }

        return true;
    }
}