namespace CarService2;
using static System.Console;

enum CurrentMenu
{
    MainMenu, CarList, PartList, StorageList
}
public class Menu
{
    private delegate void MenuAction();
    private readonly List<string> _mainMenu; //Названия пунктов главного меню. Главное меню.
    private Dictionary<string, MenuAction> _menuActions; //Список делегатов вызываемых при выборе одного из пунктов главного меню.
    private readonly int _menuIndexLower; //Нижний индекс меню, всегда равен нулю. 0
    private int _menuIndexUpper; //Верхний индекс меню равен длине текущего списка из которого выбираешь.
    private int _currentMenuIndex; // Текущий индекс меню, или тот который выбран.
    private Car _selectedCar; //Выбранная для ремонта машина записана здесь
    private CarPart _selectedCarPart;//Выбранная для ремонта запчасть записана здесь
    private CarPart _selectedPartFromStorage; //Запчасть из списка склада. Та запчасть которую берем для ремонта.
    private readonly CarService _carService;
    private bool _run;
    public Menu(CarService carService)
    {
        _mainMenu = new() { { "Start the Work" }, { "Show the Storage" }, { "Exit the Program" } };
        _carService = carService;
        _menuIndexLower = 0;
        _currentMenuIndex = 0;
        _menuActions = new Dictionary<string, MenuAction>
    {
        {"Start the Work", this.ShowCarList},
        {"Show the Storage", this.ShowMyStorage},
        {"Exit the Program", this.ExitProgram}
    };
    }
    
    private static void ClearConsole()
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
                WriteLine($"{_selectedCar.CarBrand}");
                WriteLine("Choose a part you want to replace:");
                ShowMenu(_selectedCar.CarEquipment);
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
    private void SwitchMenu(CurrentMenu position)
    {
        ConsoleKeyInfo userInput = ReadKey();
        switch (userInput.Key)
        {
            case ConsoleKey.UpArrow: //Нажимаем стрелочку вверх, меняем индекс и соответственно выбранное меню
                SelectUpperMenuOption();
                break;
            
            case ConsoleKey.DownArrow: //Нажимаем стрелочку вниз, меняем индекс и соответственно выбранное меню
                SelectLowerMenuOption();
                break;
            
            case ConsoleKey.Enter:
                switch (position)
                {
                    case CurrentMenu.MainMenu: //invoke ShowCarList method, show Car list.
                        MainMenuAction();
                        break;
                    
                    case CurrentMenu.CarList:
                        _selectedCar = _carService.Clients.Clients[_currentMenuIndex];
                        _currentMenuIndex = 0;
                        ShowParticularCar(); 
                        _run = false;
                        break;
                    
                    case CurrentMenu.PartList:
                        _selectedCarPart = _selectedCar.CarEquipment[_currentMenuIndex]; 
                        _currentMenuIndex = 0;
                        ShowStorage();
                        _run = false;
                        break;
                    
                    case CurrentMenu.StorageList:
                        _selectedPartFromStorage = _carService.Storage.Stock[_currentMenuIndex];
                        _currentMenuIndex = 0;
                        ReplaceCarPart();
                        break;
                }
                break;
        }
    }
    private void SelectLowerMenuOption()
    {
        _currentMenuIndex = (_currentMenuIndex == _menuIndexUpper - 1) ? _menuIndexLower : ++_currentMenuIndex;
    }
    private void SelectUpperMenuOption()
    {
        _currentMenuIndex = (_currentMenuIndex == 0) ? _menuIndexUpper - 1 : --_currentMenuIndex;
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
        _run = true;
        _currentMenuIndex = 0;
        while (_run)
        {
            MenuHandler(CurrentMenu.StorageList);
            SwitchMenu(CurrentMenu.StorageList); 
        }
    }
    private void ShowParticularCar()
    {
        _run = true;
        while (_run)
        {
            MenuHandler(CurrentMenu.PartList);
            SwitchMenu(CurrentMenu.PartList); 
        }
    }
    private void ShowCarList()
    {
        _run = true;
        while (_run)
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
        _carService.Vitya.StartService(_selectedCar, _selectedCarPart, _selectedPartFromStorage);
        _carService.Vitya.GetJobMessage();
        _carService.CashDesk.CalculateRepairCost(_selectedCarPart, _carService.Vitya.GetJobType());
        if (_carService.Vitya.GetJobResult())
        {
            _carService.CashDesk.MakeTransaction(_selectedCar, _carService.CashDesk);
        }
        else
        {
            _carService.CashDesk.CalculatePenaltyCost(_selectedCarPart, _carService.Vitya.GetJobType());
            _carService.CashDesk.ApplyPenalty();
        }
        _run = false;
        Thread.Sleep(2000);
    }
    private void ShowMyStorage()
    {
        ClearConsole();
        WriteLine("Showing the storage!");
        WriteLine(_carService.CashDesk.Money);
        Thread.Sleep(2000);
    }
    private void ExitProgram()
    {
        Environment.Exit(0);
    }
}