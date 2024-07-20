using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Models;
using SchoolManagement.Utils;
using MM.Utils;

namespace SchoolManagement.Functions
{
    internal class StudentsFunctions
    {
        public static void StudentsManagement(int Selection, School mySchool) 
        {
            int SelectedID;
            bool found = false;
            try
            {
                switch (Selection)
                {
                    case 1:
                    // Add Student
                        Console.Clear();
    /*                  Console.Write("Enter The First Name: ");
                        var FirstName = GeneralFunctions.ReadString();
                        Console.Write("Enter The Last Name: ");
                        var LasttName = GeneralFunctions.ReadString();
                        Console.Write("Enter The Birthdate (mm/dd/yyyy): ");
                        string BirhtDate = GeneralFunctions.ReadString();
                        DateTime ActualBD = Utils.Utils.GetDate(BirhtDate);
                        Console.Write("Enter The Address: ");
                        var Address = GeneralFunctions.ReadString();
                        Console.Write("Enter The Phone No: ");
                        var PhoneNo = GeneralFunctions.ReadString();
                        Console.Write("Enter The Department: ");
                        double GPA = GeneralFunctions.ReadDouble();
                        Console.WriteLine("Enter The Major: ");
                        int MajorSelection = MenuFunctions.CreateMenu(School.GetMajors())-1;
                        Student newStudent = new Student(IdGenerated.GenerateID(), FirstName, LasttName, ActualBD, Address, PhoneNo, GPA, MajorSelection, AllStudents);*/
                        Student newStudent = new Student("Marcelo", "Muñoz", Utils.Utils.GetDate("12/22/1993"), "Av. The Strongest", "73246114", 50.0, 1);
                        mySchool.AddToSchool(newStudent);
                        Console.WriteLine($"Student {newStudent.FirstName} was Added!");
                        newStudent.DisplayStudentInfo();
                        Console.ReadLine();
                        break;
                    case 2:
                        // Earn Credits
                        Console.Clear();
                        int CreditsErned;
                        Console.Write("Intorduce the Id of the Student: ");
                        SelectedID = GeneralFunctions.ReadNumber();
                        foreach (Student student in mySchool.Students)
                        {
                            if (student.Id == SelectedID)
                            {
                                Console.WriteLine($"Actual Amount of Credits of {student.FirstName}: {student.CreditsErned}");
                                Console.Write($"How Many Credits You want to add?:");
                                CreditsErned = GeneralFunctions.ReadNumber();
                                student.AddCredits(CreditsErned);
                                mySchool.UpdateSchool();
                                Console.WriteLine($"{CreditsErned} Credits Were added to {student.FirstName}!");
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            throw new ArgumentException("No Students foudn with the guiven ID");
                        }
                        found = false;
                        Console.ReadLine();
                        break;
                    case 3:
                        // View Student Information
                        Console.Clear();
                        Console.Write("Intorduce the Id of the Student: ");
                        SelectedID = GeneralFunctions.ReadNumber();
                        foreach(Student student in mySchool.Students)
                        {
                            if(student.Id == SelectedID)
                            {
                                student.DisplayStudentInfo();
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            throw new ArgumentException("No Students foudn with the guiven ID");
                        }
                        Console.ReadLine();
                        break;
                    default:
                        break;
            }

            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
