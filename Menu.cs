namespace CarService2;
using static System.Console;

enum CurrentMenu
{
    MainMenu, CarMenu, PartMenu, StorageMenu
}
public class Menu
{
    private delegate void MenuAction();
    private List<string> _mainMenu;
    private Dictionary<string, MenuAction> _menuActions;
    private int _menuIndexLower;
    private int _menuIndexUpper;
    private int _menuObject;
    private MarketGenerator _clientList;
    private CarService _carService;
    private Storage _storage;
    private Car CarToRepair;
    public Menu(MarketGenerator street, CarService carService, Storage storage)
    {
        _mainMenu = new() { { "Start the Work" }, { "Show the Storage" }, { "Exit the Program" } };
        _clientList = street;
        _carService = carService;
        _storage = storage;
        _menuIndexLower = 0;
        _menuObject = 0;
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
        MenuHandler(CurrentMenu.MainMenu);
        SwitchMenu(CurrentMenu.MainMenu);
        
    }
    
    
    private void MenuHandler(CurrentMenu position)
    {
        ClearConsole();
        CurrentMenu menuPosition = position;
        switch (menuPosition)
        {
            case CurrentMenu.MainMenu:
                ShowMenu(_mainMenu);
                break;
            case CurrentMenu.CarMenu:
                ShowMenu(_clientList.Clients);
                break;
            case CurrentMenu.PartMenu:
                ShowMenu(_clientList.Clients[_menuObject].CarEquipment);
                break;
            case CurrentMenu.StorageMenu:
                ShowMenu(_storage.Stock);
                break;
        }
    }

    private void ShowMenu<T>(List<T> list)
    {
        _menuIndexUpper = list.Count;
        for (int i = 0; i < _menuIndexUpper; i++)
        {
            WriteLine(_menuObject == i 
                ? $">>{list[i]}<<"
                : $"{list[i]}");
        }
    }

    private void SwitchMenu(CurrentMenu position)
    {
        //CurrentMenu menuPosition = position;
        ConsoleKeyInfo userInput = ReadKey();
        switch (userInput.Key)
        {
            case ConsoleKey.UpArrow:
                _menuObject = (_menuObject == 0) ? _menuIndexUpper - 1 : --_menuObject;
                break;
            
            case ConsoleKey.DownArrow:
                _menuObject = (_menuObject == _menuIndexUpper - 1) ? _menuIndexLower : ++_menuObject;
                break;
            
            case ConsoleKey.Enter:
                switch (position)
                {
                    case CurrentMenu.MainMenu:
                        MainMenuAction();
                        break;
                    
                    case CurrentMenu.CarMenu:
                        ShowParticularCar();
                        break;
                    
                    case CurrentMenu.PartMenu:
                        RepairCarPart();
                        break;
                    
                    case CurrentMenu.StorageMenu:
                        //replace Car Part
                        break;
                }
                break;
        }
    }

    private void MainMenuAction()
    {
        string chosenMenuIndex = _mainMenu[_menuObject];
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
        WriteLine(CarToRepair.CarEquipment[_menuObject]);
        WriteLine("Choose the part to replace from storage:");
        MenuHandler(CurrentMenu.StorageMenu);
        SwitchMenu(CurrentMenu.StorageMenu);
    }

    private void ShowParticularCar()
    {
        ClearConsole();
        WriteLine(CarToRepair);
        MenuHandler(CurrentMenu.PartMenu);
        SwitchMenu(CurrentMenu.PartMenu);
        
    }
    private void StartWork()
    {
        WriteLine("These are clients for today:");
        MenuHandler(CurrentMenu.CarMenu);
        SwitchMenu(CurrentMenu.CarMenu);
        WriteLine("Choose client to serve by pressing UP and DOWN arrows.");
        Thread.Sleep(7000);
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