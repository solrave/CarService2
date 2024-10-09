namespace CarService2;
using static System.Console;

enum CurrentMenu
{
    MainMenu, CarList, PartList, StorageList
}
public class Menu
{
    private delegate void MenuAction();
    private List<string> _mainMenu;
    private Dictionary<string, MenuAction> _menuActions;
    private int _menuIndexLower;
    private int _menuIndexUpper;
    private int _menuObject;
    private int _selectedCar;
    private int _selectedPart;
    private int _selectedStoragePart;
    private MarketGenerator _clientList;
    private CarService _carService;
    private Storage _storage;
    private Car CarToRepair;
    private bool run;
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
        {"Start the Work", new (this.ShowCarList)},
        {"Show the Storage", new (this.ShowMyStorage)},
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
                WriteLine("Welcome to the Car Service!");
                ShowMenu(_mainMenu);
                break;
            case CurrentMenu.CarList:
                WriteLine("These are your clients for today:");
                ShowMenu(_clientList.Clients);
                break;
            case CurrentMenu.PartList:
                WriteLine($"{_clientList.Clients[_menuObject].CarBrand}");
                WriteLine("Choose a part you want to replace:");
                ShowMenu(_clientList.Clients[_menuObject].CarEquipment);
                break;
            case CurrentMenu.StorageList:
                WriteLine("Choose part to replace from storage:");
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
                    case CurrentMenu.MainMenu: //invoke ShowCarList method, show Car list.
                        MainMenuAction();
                        break;
                    
                    case CurrentMenu.CarList:
                        ShowParticularCar(); //Should save selected car for later.
                        run = false;
                        break;
                    
                    case CurrentMenu.PartList:
                        ShowStorage();
                        run = false;
                        break;
                    
                    case CurrentMenu.StorageList:
                        ReplaceCarPart();
                        break;
                }
                break;
        }
    }

    private void MainMenuAction() //Enter key
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
    
    private void ShowStorage() //Enter key
    {
        run = true;
        _selectedPart = _menuObject;
        _menuObject = 0;
        while (run)
        {
            MenuHandler(CurrentMenu.StorageList);
            SwitchMenu(CurrentMenu.StorageList); 
        }
    }

    private void ShowParticularCar() //Enter key
    {
        _selectedCar = _menuObject;
        _menuObject = 0;
        run = true;
        while (run)
        {
            MenuHandler(CurrentMenu.PartList);
            SwitchMenu(CurrentMenu.PartList); 
        }
        
        
        
    }
    private void ShowCarList() //Invoke from delegates list
    {
        run = true;
        while (run)
        {
            WriteLine("These are clients for today:");
            MenuHandler(CurrentMenu.CarList);
            WriteLine("Choose client to serve by pressing UP and DOWN arrows.");
            SwitchMenu(CurrentMenu.CarList);
        }
        
    }

    private void ReplaceCarPart()
    {
        _selectedStoragePart = _menuObject;
        _carService.PerformJob(_clientList.Clients[_selectedCar], _selectedPart, _storage, _selectedStoragePart);
        WriteLine("Part have been replaced!");
    }

    private void ShowMyStorage()
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