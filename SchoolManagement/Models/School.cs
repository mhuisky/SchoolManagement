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
        public List<Student> SchoolStudents;
        public List<Teacher> Teachers;
        public List<Course> Courses;

        public string StudentFilePath = "C:\\Users\\marcelo.munoz\\source\\repos\\SchoolManagement\\Students.txt";
        public string TeacherFilePath = "C:\\Users\\marcelo.munoz\\source\\repos\\SchoolManagement\\Teachers.txt";
        public string CourseFilePath = "C:\\Users\\marcelo.munoz\\source\\repos\\SchoolManagement\\Courses.txt";


        public IDGenerator StudentidGenerator = new IDGenerator();

        public School()
        {
            SchoolStudents = new List<Student>();
            Teachers = new List<Teacher>();
            Courses = new List<Course>();

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
        }
        public void InitiateSchool(List<Student> NewStudents, List<Teacher> NewTeachers, List<Course> NewCourses, IDGenerator StudentId, IDGenerator TeacherId)
        {
            foreach(Student student in NewStudents)
            {
                SchoolStudents.Add(student);
                StudentId.currentID++;
            }

            foreach (Teacher teacher in NewTeachers)
            {
                Teachers.Add(teacher);
                TeacherId.currentID++;
            }

            foreach(Course course in NewCourses)
            {
                Courses.Add(course);
            }
        }
        public void AddToSchool(Student newStudent)
        {
            SchoolStudents.Add(newStudent);
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Student>>(StudentFilePath, SchoolStudents);
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
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Student>>(StudentFilePath, SchoolStudents);
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Course>>(CourseFilePath, Courses);
            GeneralFunctions.JsonSerialization.WriteToJsonFile<List<Teacher>>(TeacherFilePath, Teachers);
        }

/*        public enum Major
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
        }*/
    }
}
