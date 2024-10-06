namespace CarService2;
using static System.Console;
public class Menu
{
    private delegate void MenuAction();
    private List<string> _menuOptions;
    private Dictionary<string, MenuAction> _menuActions;
    private int _menuIndexLower;
    private int _menuIndexUpper;
    private int _currentMenuIndex;
    private MarketGenerator _street;
    private CarService _carService;
    private Storage _storage;
    private Car CarToRepair;
    public Menu(MarketGenerator street, CarService carService, Storage storage)
    {
        _menuOptions = new() { { "Start the Work" }, { "Show the Storage" }, { "Exit the Program" } };
        _street = street;
        _carService = carService;
        _storage = storage;
        _menuIndexLower = 0;
        _currentMenuIndex = 0;
        _menuActions = new Dictionary<string, MenuAction>
    {
        {"Start the Work", new (this.StartWork)},
        {"Show the Storage", new (this.ShowStorage)},
        {"Exit the Program", new (this.ExitProgram)}
    };
    }
    
    private void ClearConsole()
    {
        Clear();
        WriteLine("\x1b[3J");
    }

    public void RunMenu()
    {
        ShowMenu(_menuOptions);
        SwitchMenu(_menuOptions);
    }
    
    
    private void ShowMenu<T>(List<T> list)
    {
        ClearConsole();
        _menuIndexUpper = list.Count;
        for (int i = 0; i < _menuIndexUpper; i++)
        {
            WriteLine(_currentMenuIndex == i 
                ? $">>{list[i]}<<"
                : $"{list[i]}");
        }
        
    }
    
    private void SwitchMenu<T>(List<T> list)
    {
        ConsoleKeyInfo userInput = ReadKey();
        switch (userInput.Key)
        {
            case ConsoleKey.UpArrow:
                _currentMenuIndex = (_currentMenuIndex == 0) ? _menuIndexUpper - 1 : --_currentMenuIndex;
                break;
            
            case ConsoleKey.DownArrow:
                _currentMenuIndex = (_currentMenuIndex == _menuIndexUpper - 1) ? _menuIndexLower : ++_currentMenuIndex;
                break;
            
            case ConsoleKey.Enter:
                Type TypeOfT = typeof(T);
                if (TypeOfT == typeof(string))
                {
                    PressEnterMainMenu();
                }
                else if (TypeOfT == typeof(Car))
                {
                    ShowParticularCar();
                }
                else if (TypeOfT == typeof(CarPart))
                {
                    RepairCarPart();
                }
                break;
        }
    }

    private void PressEnterMainMenu()
    {
        string chosenMenuIndex = _menuOptions[_currentMenuIndex];
        if (_menuActions.TryGetValue(chosenMenuIndex.ToString(), out MenuAction action))
        {
            action.Invoke();
        }
        else
        {
            WriteLine("Error! No such menu index!");
        }  
    }
    
    private void RepairCarPart()
    {
        ClearConsole();
        WriteLine(CarToRepair);
        WriteLine(CarToRepair.CarEquipment[_currentMenuIndex]);
        WriteLine("Choose the part to replace from storage:");
        ShowMenu(_storage.Stock);
    }

    private void ShowParticularCar()
    {
        ClearConsole();
        WriteLine(CarToRepair);
        ShowMenu(_street.Clients[_currentMenuIndex].CarEquipment);
        
    }
    private void StartWork()
    {
        WriteLine("These are clients for today:");
        ShowMenu(_street.Clients);
        SwitchMenu(_street.Clients);
        WriteLine("Choose client to serve by pressing UP and DOWN arrows.");
        //Thread.Sleep(7000);
    }

    private void ShowStorage()
    {
        ClearConsole();
        WriteLine("Showing the storage!");
        Thread.Sleep(2000);
    }

    private void ExitProgram()
    {
        Environment.Exit(0);
    }
}