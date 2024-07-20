using MM.Utils;
using SchoolManagement.Models;
using SchoolManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolManagement.Functions
{
    internal class StaffFunctions
    {
        public static void StafManagement(int Selection, School mySchool)
        {
            int SelectedID;
            bool found = false;

            try
            {
                switch (Selection)
                {
                    case 1:
                        // Add Teacher
                        Console.Clear();
                        /*Console.Write("Enter The First Name: ");
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
                        string Department = GeneralFunctions.ReadString();
                        Console.WriteLine("Enter The Specialization: ");
                        string Specialization = GeneralFunctions.ReadString();
                        Console.WriteLine("Enter The Salary: ");
                        decimal Salary = GeneralFunctions.ReadDecimal();
                        Teacher newTeacher = new Teacher(IdGenerated.GenerateID(), FirstName, LasttName, ActualBD, Address, PhoneNo, Department, Specialization, Salary);*/
                        Teacher newTeacher = new Teacher("Marcelo", "Muñoz", Utils.Utils.GetDate("12/22/1993"), "Av. The Strongest", "73246114", "Math", "Arithmetics", 4500);
                        mySchool.AddToSchool(newTeacher);
                        Console.WriteLine($"Teacher {newTeacher.FirstName} was Added!");
                        newTeacher.DisplayTeacherInfo();
                        Console.ReadLine();
                        break;
                    case 2:
                        // View Teacher Info
                        Console.Clear();
                        Console.Write("Intorduce the Id of the Teacher: ");
                        SelectedID = GeneralFunctions.ReadNumber();
                        foreach (Teacher teacehr in mySchool.Teachers)
                        {
                            if (teacehr.Id == SelectedID)
                            {
                                teacehr.DisplayTeacherInfo();
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            throw new ArgumentException("No Teachers foudn with the guiven ID");
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
