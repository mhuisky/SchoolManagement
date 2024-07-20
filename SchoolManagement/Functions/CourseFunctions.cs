using MM.Utils;
using SchoolManagement.Models;
using SchoolManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Functions
{
    internal class CourseFunctions
    {
        public static void CourseManagement(int Selection, School mySchool)
        {
            bool courseFound = false;
            bool studentFound = false;
            bool teacherFound = false;
            string SelectedCourse;

            try
            {
                switch (Selection)
                {
                    case 1:
                        //Create Curse
                        Console.Clear();
                        Course newCourse = new Course("Math 01", 5, "Mathematics  01", "MW 10-11:30AM", 80, 60);
                        mySchool.AddToSchool(newCourse);
                        Console.WriteLine($"Course {newCourse.CourseName} was Added!");
                        newCourse.DisplayCourseInfo();
                        Console.ReadLine();
                        break;
                    case 2:
                        //Enroll Student
                        Console.Clear();
                        Console.Write("Please Enter the course ID: ");
                        SelectedCourse = GeneralFunctions.ReadString();
                        foreach (Course course in mySchool.Courses)
                        {
                            if (course.ShortID == SelectedCourse)
                            {
                                Console.Write("Intorduce the Id of the Student: ");
                                int SelectedStudent = GeneralFunctions.ReadNumber();
                                foreach (Student student in mySchool.Students)
                                {
                                    if (student.Id == SelectedStudent)
                                    {
                                        if (student.GPA < course.MinGPA)
                                        {
                                            throw new ArgumentException($"The Studnet {student.FirstName} does not meet the Rquiered GPA!");
                                        }

                                        if (student.CreditsErned < course.Credits)
                                        {
                                            throw new ArgumentException($"The Studnet {student.FirstName} does not Have the Rquiered Credits!");
                                        }
                                        course.EnrollStudnet(student);
                                        mySchool.UpdateSchool();
                                        studentFound = true;
                                    }
                                }
                                if (!studentFound)
                                {
                                    throw new ArgumentException("No Students foudn with the guiven ID");
                                }
                                courseFound = true;
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
                    case 3:
                        // Assign Teacher to the course
                        Console.Clear();
                        Console.Write("Please Enter the course ID: ");
                        SelectedCourse = GeneralFunctions.ReadString();
                        foreach (Course course in mySchool.Courses)
                        {
                            if (course.ShortID == SelectedCourse)
                            {
                                Console.Write("Intorduce the Id of the Teacher: ");
                                int SelectedTeacher = GeneralFunctions.ReadNumber();
                                foreach (Teacher teacher in mySchool.Teachers)
                                {
                                    if (teacher.Id == SelectedTeacher)
                                    {
                                        course.AddTeacher(teacher);
                                        mySchool.UpdateSchool();
                                        teacherFound = true;
                                    }
                                }
                                if (!teacherFound)
                                {
                                    throw new ArgumentException("No Teachers foudn with the guiven ID");
                                }
                                courseFound = true;
                            }
                        }
                        if (!courseFound)
                        {
                            throw new ArgumentException($"No Course Found wiht ID: {SelectedCourse}");
                        }
                        teacherFound = false;
                        courseFound = false;
                        Console.ReadLine();
                        break;
                    case 4:
                        // View Course Information
                        Console.Clear();
                        Console.Write("Please Enter the course ID: ");
                        SelectedCourse = GeneralFunctions.ReadString();
                        foreach (Course course in mySchool.Courses)
                        {
                            if (course.ShortID == SelectedCourse)
                            {
                                course.DisplayCourseInfo();
                                courseFound = true;
                            }
                        }
                        if (!courseFound)
                        {
                            throw new ArgumentException($"No Course Found wiht ID: {SelectedCourse}");
                        }
                        Console.ReadLine();
                        break;
                    case 5:
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
