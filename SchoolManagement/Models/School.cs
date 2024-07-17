using MM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SchoolManagement.Models
{
    
    internal class School
    {
        public List<Student> Students;
        public List<Teacher> Teachers = new List<Teacher>();
        public List<Course> Courses = new List<Course>();

        public School()
        {
            Students = new List<Student>();
/*          Teachers = new List<Teacher>();
            Courses = new List<Course>();*/
        }

        public void AddToSchool(Student newStudent)
        {
            Students.Add(newStudent);
        }

        public void AddToSchool(Teacher newValue)
        {
            Teachers.Add(newValue);
        }

        public void AddToSchool(Course newValue)
        {
            Courses.Add(newValue);
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
