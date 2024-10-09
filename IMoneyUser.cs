namespace CarService2;
using static System.Console;
public interface IMoneyUser
{
    int Money { get; set; }

    //void TransferMoneyTo(IMoneyUser receiver, int amount);
}