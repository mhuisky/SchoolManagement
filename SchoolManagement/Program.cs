using MM.Utils;
using SchoolManagement.Functions;
using SchoolManagement.Models;
using SchoolManagement.Utils;
using System.IO;

string[] MainMenu = { "Students", "Staff", "Courses", "Grades", "Exit" };
string[] StudentMenu = { "Add Student", "Earn Credits", "View Student Information", "Back" };
string[] StafftMenu = { "Add Teacher","View Teacher Information", "Back" };
string[] CursesMenu = { "Create Curses", "Enroll Student In Course", "Assing Teacher to course", "View Course Information", "Back" };
string[] GradesMenu = { "Grade Course", "List Course Grate", "List Approved Students", "List Failed Students", "Back" };

int selection = 0;
int studentSelection = 0;
int staffSelection = 0;
int courseSelection = 0;
int gradeSelection = 0;

string StudentFilePath = "C:\\Users\\marcelo.munoz\\source\\repos\\SchoolManagement\\Students.txt";

if (!File.Exists(StudentFilePath))
{
    using (FileStream fs = File.Create(StudentFilePath))
    {
    }
    using (StreamWriter sw = new StreamWriter(StudentFilePath))
    {
        sw.Write("[]");
    }
}

List<Student> AllStudents = GeneralFunctions.JsonSerialization.ReadFromJsonFile<List<Student>>(StudentFilePath);

IDGenerator StudentidGenerator = new IDGenerator();
School mySchool = new School();

foreach (Student student in AllStudents)
{
    mySchool.Students.Add(student);
    StudentidGenerator.currentID++;
}


do
{
    MenuFunctions.PrintHeader("School Management");
    selection = MenuFunctions.CreateMenu(MainMenu);
    try
    {
        switch (selection)
        {
            case 1:
                Console.Clear();
                
                do
                {
                    MenuFunctions.PrintHeader("Students");
                    studentSelection = MenuFunctions.CreateMenu(StudentMenu);
                    StudentsFunctions.StudentsManagement(studentSelection, StudentidGenerator, mySchool, StudentFilePath, AllStudents);
                    Console.Clear();
                } while (studentSelection != 4);
                break;
            case 2:
                Console.Clear();
                do
                {
                    MenuFunctions.PrintHeader("Staff");
                    staffSelection = MenuFunctions.CreateMenu(StafftMenu);
                    Console.Clear();
                } while (staffSelection != 3);
                break;
            case 3:
                Console.Clear();
                do
                {
                    MenuFunctions.PrintHeader("Courses");
                    courseSelection = MenuFunctions.CreateMenu(CursesMenu);
                    Console.Clear();
                } while (courseSelection != 5);
                break;
            case 4:
                Console.Clear();
                do
                {
                    MenuFunctions.PrintHeader("Grades");
                    gradeSelection = MenuFunctions.CreateMenu(GradesMenu);
                    Console.Clear();
                } while (gradeSelection != 5);
                break;
            default:
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Something Went Wrong in School!");
        Console.WriteLine(ex.Message);
        Console.ReadLine();
    }
Console.Clear();
} while (selection != 5);


            
