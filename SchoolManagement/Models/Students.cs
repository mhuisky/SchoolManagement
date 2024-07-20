using SchoolManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SchoolManagement.Models
{
    internal class Student : People
    {
        private int _id;
        private DateTime _enrrollmentDate;
        private Major _major;
        private double _gpa;
        private int _creditsErned;
        private List <Grade> _grades;
        private List<Course> _studentCourses;

        public int Id 
        {
            get
            {
                return _id;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id Can't Be Negative");
                }
                _id = value;
            }
        }
        public DateTime EnrrollmentDate
        {
            get
            {
                return _enrrollmentDate;
            }
            set
            {
                _enrrollmentDate = value;
            }
        }
        public Major StudentMajor
        {
            get
            {
                return _major;
            }
            set
            {
                _major = value;
            }
        }
        public double GPA
        {
            get
            {
                return _gpa;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("GPA Can't Be Negative");
                }
                _gpa = value;
            }
        }
        public int CreditsErned
        {
            get
            {
                return _creditsErned;
            }
            set
            {
                _creditsErned = value;
            }
        }

        public List<Grade> StudentGrades
        {
            get
            {
                return _grades;
            }
            set
            {
                _grades = value;
            }
        }

        public Student(string newFirstName, string newLastName, DateTime newBirthDate, string newAddress, string newPhoneNo, double newGPA, int newMajor) : base(newFirstName, newLastName, newBirthDate, newAddress, newPhoneNo)
        {
            _id = base.StudentidGenerator.GenerateID();
            _gpa = newGPA;
            _enrrollmentDate = DateTime.Now;
            _major = (Major)newMajor;
            _grades = new List<Grade>();
            _studentCourses = new List<Course>();
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("First Name: " + FirstName);
            Console.WriteLine("Birth Date: " + BirthDate.ToString("d"));
            Console.WriteLine("Major: " + StudentMajor);
            Console.WriteLine("EnrrollmentDate: " + EnrrollmentDate.ToString("d"));
            Console.WriteLine("Credits: " + CreditsErned);
        }

        public void AddCredits(int Value)
        {
            if (Value < 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            CreditsErned = CreditsErned + Value;
        }
    }

}
