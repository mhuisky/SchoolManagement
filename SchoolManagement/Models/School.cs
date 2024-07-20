using MM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SchoolManagement.Utils;

namespace SchoolManagement.Models
{
    
    internal class School
    {
        public List<Student> Students;
        public List<Teacher> Teachers;
        public List<Course> Courses;
        //public List<Grade> Grades;


        public IDGenerator StudentidGenerator = new IDGenerator();
        public IDGenerator TeacheridGenerator = new IDGenerator();

        public string StudentFilePath = "C:\\Users\\marcelo.munoz\\source\\repos\\SchoolManagement\\Students.txt";
        public string TeacherFilePath = "C:\\Users\\marcelo.munoz\\source\\repos\\SchoolManagement\\Teachers.txt";
        public string CourseFilePath = "C:\\Users\\marcelo.munoz\\source\\repos\\SchoolManagement\\Courses.txt";

        public School()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Courses = new List<Course>();
            //Grades = new List<Grade>();


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

            if (!File.Exists(TeacherFilePath))
            {
                using (FileStream fs = File.Create(TeacherFilePath))
                {
                }
                using (StreamWriter sw = new StreamWriter(TeacherFilePath))
                {
                    sw.Write("[]");
                }
            }

            if (!File.Exists(CourseFilePath))
            {
                using (FileStream fs = File.Create(CourseFilePath))
                {
                }
                using (StreamWriter sw = new StreamWriter(CourseFilePath))
                {
                    sw.Write("[]");
                }
            }
/*
            Students = GeneralFunctions.JsonSerialization.ReadFromJsonFile<List<Student>>(StudentFilePath);
            Teachers = GeneralFunctions.JsonSerialization.ReadFromJsonFile<List<Teacher>>(TeacherFilePath);
            Courses = GeneralFunctions.JsonSerialization.ReadFromJsonFile<List<Course>>(CourseFilePath);*/


        }

        public void AddToSchool(Student newStudent)
        {
            Students.Add(newStudent);
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Student>>(StudentFilePath, Students);
        }
        public void AddToSchool(Teacher newValue)
        {
            Teachers.Add(newValue);
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Teacher>>(TeacherFilePath, Teachers);
        }
        public void AddToSchool(Course newValue)
        {
            Courses.Add(newValue);
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Course>>(CourseFilePath, Courses);
        }
        
        public void UpdateSchool()
        {
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Course>>(CourseFilePath, Courses);
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Student>>(StudentFilePath, Students);
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Teacher>>(TeacherFilePath, Teachers);
            
        }
        public enum Major
        {
            Engeniering,
            Medicine,
            Administration,
            Languages,
            Economycs
        }

        public static string[] GetMajors()
        {
            string[] Majors = Enum.GetNames(typeof(Major));
            return Majors;
        }
    }
}
