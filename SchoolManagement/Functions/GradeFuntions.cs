using MM.Utils;
using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Functions
{
    internal class GradeFuntions
    {
        public static void GradeManagement(int Selection, School mySchool)
        {
            string SelectedCourse;
            bool courseFound = false;
            bool studentFound = false;
            try
            {
                switch (Selection)
                {
                    case 1:
                        // Grade Course
                        Console.Clear();
                        Console.Write("Please Enter the course ID: ");
                        SelectedCourse = GeneralFunctions.ReadString();
                        foreach (Course course in mySchool.Courses)
                        {
                            if (course.ShortID == SelectedCourse)
                            {
                                Console.Write("Intorduce the Id of the Student: ");
                                int SelectedStudent = GeneralFunctions.ReadNumber();
                                foreach (Student student in course.CourseStudents)
                                {
                                    if (student.Id == SelectedStudent)
                                    {
                                        Console.Write("Plase Add the Grade: ");
                                        double AddGrade = GeneralFunctions.ReadDouble();
                                        Grade newGrade = new Grade(course, student, AddGrade);
                                        course.CourseGrades.Add(newGrade);
                                        student.StudentGrades.Add(newGrade);
                                        mySchool.UpdateSchool();
                                        Console.Clear();
                                        Console.Write("Grade set Successfully!");
                                        studentFound = true;
                                        break;
                                    }
                                }
                                if (!studentFound)
                                {
                                    throw new ArgumentException("No Students foudn with the guiven ID in the selected Course");
                                }
                                courseFound = true;
                                break;
                            }
                        }
                        if (!courseFound)
                        {
                            throw new ArgumentException($"No Course Found wiht ID: {SelectedCourse}");
                        }
                        studentFound = false;
                        courseFound = false;
                        Console.ReadLine();
                        break;
                    case 2:
                        // List Course Grades
                        Console.Clear();
                        Console.Write("Please Enter the course ID: ");
                        SelectedCourse = GeneralFunctions.ReadString();
                        foreach (Course course in mySchool.Courses)
                        {
                            if (course.ShortID == SelectedCourse)
                            {
                                Console.WriteLine("Approval Score: " + course.ApprovalScore);
                                foreach(Grade grade in course.CourseGrades)
                                {
                                    Console.WriteLine($"Student: {grade.Student.FirstName} {grade.Student.LastName}  |   Grade: {grade.Score}" );
                                }
                                courseFound = true;
                                break;
                            }
                        }
                        if (!courseFound)
                        {
                            throw new ArgumentException($"No Course Found wiht ID: {SelectedCourse}");
                        }
                        courseFound = false;
                        Console.ReadLine();
                        break;
                    case 3:
                        // List Approved Students
                        Console.Clear();
                        Console.Write("Please Enter the course ID: ");
                        SelectedCourse = GeneralFunctions.ReadString();
                        foreach (Course course in mySchool.Courses)
                        {
                            if (course.ShortID == SelectedCourse)
                            {
                                foreach (Grade grade in course.CourseGrades)
                                {
                                    if (grade.Score > course.ApprovalScore)
                                    {
                                        Console.WriteLine($"Student: {grade.Student.FirstName} {grade.Student.LastName} |   Grade: {grade.Score}");
                                    }                                   
                                }
                                courseFound = true;
                                break;
                            }
                        }
                        if (!courseFound)
                        {
                            throw new ArgumentException($"No Course Found wiht ID: {SelectedCourse}");
                        }
                        courseFound = false;
                        Console.ReadLine();
                        break;
                    case 4:
                        // List Failed Studetns
                        Console.Clear();
                        Console.Write("Please Enter the course ID: ");
                        SelectedCourse = GeneralFunctions.ReadString();
                        foreach (Course course in mySchool.Courses)
                        {
                            if (course.ShortID == SelectedCourse)
                            {
                                foreach (Grade grade in course.CourseGrades)
                                {
                                    if (grade.Score < course.ApprovalScore)
                                    {
                                        Console.WriteLine($"Student: {grade.Student.FirstName} {grade.Student.LastName}  |   Grade: {grade.Score}");
                                    }
                                }
                                courseFound = true;
                                break;
                            }
                        }
                        if (!courseFound)
                        {
                            throw new ArgumentException($"No Course Found wiht ID: {SelectedCourse}");
                        }
                        courseFound = false;
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
