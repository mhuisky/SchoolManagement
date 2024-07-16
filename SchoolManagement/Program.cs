// See https://aka.ms/new-console-template for more information
using MM.Utils;
string[] MainMenu = { "Students", "Staff", "Courses", "Grades", "Exit" };
int selection = 0;
do
{
  selection = MenuFunctions.CreateMenu(MainMenu);
} while (selection != 4);
