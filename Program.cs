// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using CarService2;

MarketGenerator Street = new MarketGenerator();
Menu main = new Menu(Street);
bool run = true;
while (run)
{
main.ShowMainMenu();
//main.SwitchMainMenu();
}