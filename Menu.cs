namespace CarService2;
using static System.Console;

enum CurrentMenu
{
    MainMenu, CarList, PartList, StorageList
}
public class Menu
{
    private delegate void MenuAction();
    private List<string> _mainMenu; //Названия пунктов главного меню. Главное меню.
    private Dictionary<string, MenuAction> _menuActions; //Список делегатов вызываемых при выборе одного из пунктов главного меню.
    private int _menuIndexLower; //Нижний индекс меню, всегда равен нулю. 0
    private int _menuIndexUpper; //Верхний индекс меню равен длине текущего списка из которого выбираешь.
    private int _currentMenuIndex; // Текущий индекс меню, или тот который выбран.
    private int _selectedCar; //Номер машины в списке, которую выбрал. Та машина которую чиним.
    private int _selectedCarPart; //Номер запчасти в списке, которую выбрал. Та запчасть которую меняем.
    private int _selectedPartFromStorage; //Номер запчасти из списка склада. Та запчасть которую берем для ремонта.
    private int _carPartsIndex; //
    //private Car _selectedCarFromList;
    //private CarPart _selectedCarPart;
    private CarService _carService;
    private Car CarToRepair;
    private bool run;
    public Menu(MarketGenerator street, CarService carService)
    {
        _mainMenu = new() { { "Start the Work" }, { "Show the Storage" }, { "Exit the Program" } };
        _carService = carService;
        _menuIndexLower = 0;
        _currentMenuIndex = 0;
        _carPartsIndex = 0;
        _selectedCar = 0;
        _selectedCarPart = 0;
        _selectedPartFromStorage = 0;
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
                ShowMenu(_carService.Clients.Clients);
                break;
            case CurrentMenu.PartList:
                WriteLine($"{_carService.Clients.Clients[_currentMenuIndex].CarBrand}");
                WriteLine("Choose a part you want to replace:");
                ShowCarPartMenu(_carService.Clients.Clients[_currentMenuIndex].CarEquipment);
                break;
            case CurrentMenu.StorageList:
                WriteLine("Choose part to replace from storage:");
                ShowMenu(_carService.Storage.Stock);
                break;
        }
    }

    private void ShowMenu<T>(List<T> list)
    {
        _menuIndexUpper = list.Count;
        for (int i = 0; i < _menuIndexUpper; i++)
        {
            WriteLine(_currentMenuIndex == i 
                ? $">>{list[i]}<<"
                : $"{list[i]}");
        }
    }
    
    private void ShowCarPartMenu<T>(List<T> list)
    {
        _menuIndexUpper = list.Count;
        for (int i = 0; i < _menuIndexUpper; i++)
        {
            WriteLine(_carPartsIndex == i 
                ? $">>{list[i]}<<"
                : $"{list[i]}");
        }
    }

    private void SwitchMenu(CurrentMenu position)
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
                switch (position)
                {
                    case CurrentMenu.MainMenu: //invoke ShowCarList method, show Car list.
                        MainMenuAction();
                        break;
                    
                    case CurrentMenu.CarList:
                        _selectedCar = _currentMenuIndex;
                        _currentMenuIndex = 0;
                        ShowParticularCar(); 
                        run = false;
                        break;
                    
                    case CurrentMenu.StorageList:
                        _selectedPartFromStorage = _currentMenuIndex;
                        _currentMenuIndex = 0;
                        ReplaceCarPart();
                        break;
                }
                break;
        }
    }
    private void SwitchCarPartMenu()
    {
        ConsoleKeyInfo userInput = ReadKey();
        switch (userInput.Key)
        {
            case ConsoleKey.UpArrow:
                _carPartsIndex = (_carPartsIndex == 0) ? _menuIndexUpper - 1 : --_carPartsIndex;
                break;
            
            case ConsoleKey.DownArrow:
                _carPartsIndex = (_carPartsIndex == _menuIndexUpper - 1) ? _menuIndexLower : ++_carPartsIndex;
                break;
            
            case ConsoleKey.Enter:
                _selectedCarPart = _carPartsIndex;
                _currentMenuIndex = 0;
                ShowStorage();
                run = false;
                break;
        }
    }

    private void MainMenuAction()
    {
        string chosenMenuIndex = _mainMenu[_currentMenuIndex];
        if (_menuActions.TryGetValue(chosenMenuIndex.ToString(), out MenuAction action))
        {
            action.Invoke();
        }
        else
        {
            WriteLine("Error! No such menu index!");
        }  
    }
    
    private void ShowStorage() 
    {
        run = true;
        _selectedCarPart = _carPartsIndex;
        //_selectedCarPart = _selectedCarFromList.CarEquipment[_currentMenuIndex];
        _currentMenuIndex = 0;
        while (run)
        {
            MenuHandler(CurrentMenu.StorageList);
            SwitchMenu(CurrentMenu.StorageList); 
        }
    }

    private void ShowParticularCar()
    {
        run = true;
        while (run)
        {
            MenuHandler(CurrentMenu.PartList);
            SwitchCarPartMenu(); 
        }
        
        
        
    }
    private void ShowCarList()
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
        ClearConsole();
        WriteLine(_carService.PerformJob(_selectedCar, _selectedCarPart, _selectedPartFromStorage));
        run = false;
        Thread.Sleep(2000);
    }

    private void ShowMyStorage()
    {
        ClearConsole();
        WriteLine("Showing the storage!");
        WriteLine(_carService.Storage.Stock);
        Thread.Sleep(2000);
    }

    private void ExitProgram()
    {
        Environment.Exit(0);
    }
}