using MM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    internal class Course
    {
        private static Guid _id;
        private string _coursename;
        private int _credits;
        private Teacher _teacher;
        private List<Student> _students;
        private string _description;
        private string _schedule;
        // private enum
        private decimal _approvalScore;
        private double _minGPA;

        private static Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ShortID = GeneralFunctions.GetShortId(Id);
        public string CourseName
        {
            get { return _coursename; }
            set { _coursename = value; }
        }
        public int Credits
        {
            get { return _credits; }
            set { _credits = value; }
        }
        public Teacher CourseTeacher
        {
            get 
            {
                if (_teacher == null)
                {
                    Teacher emptyTeacher = new Teacher(0,"N/A","", Utils.Utils.GetDate("1/1/0001"), "", "","","",0);
                    return emptyTeacher;
                }
                return _teacher; 
            }
            set { _teacher = value; }
        }
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public decimal ApprovalScore
        {
            get { return _approvalScore; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Approval Score Can't be Negative!");
                }
                _approvalScore = value; 
            }
        }
        public double MinGPA
        {
            get { return _minGPA; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("MinGap Can't be Negative!");
                }
                _minGPA = value; 
            }
        }

        public Course( string NewCourseName, int newCredits, string newDescription, string newSchedule, decimal newApprovalScore, double newMinGPA)
        {
            _id = Guid.NewGuid();
            _coursename = NewCourseName;
            _credits = newCredits;
            _description = newDescription;
            _approvalScore = newApprovalScore;
            _minGPA = newMinGPA;
            _schedule = newSchedule;
            //_teacher = new Teacher();
            _students = new List<Student>();

        }

        public void EnrollStudnet(Student newStudent)
        {
            Students.Add(newStudent);
            Console.WriteLine($"Studnet {newStudent.FirstName} was Added To the Course {CourseName}!");
        }

        public void AddTeacher(Teacher newTeacher)
        {
            CourseTeacher = newTeacher;
            Console.WriteLine($"Teacher {newTeacher.FirstName} was Added To the Course {CourseName}!");
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine("Course ID: " + ShortID);
            Console.WriteLine("Course Name: " + CourseName);
            Console.WriteLine("Course Description: " + Description);
            Console.WriteLine("Schedule: " + _schedule);
            Console.WriteLine("Credits: " + Credits);
            Console.WriteLine("Approval Score: " + ApprovalScore);
            Console.WriteLine("Min GPA: " + MinGPA);
            Console.WriteLine("Teacher: " + CourseTeacher.FirstName);
            Console.WriteLine("Students: ");
            foreach(Student student in Students) 
            {
                Console.WriteLine("------------------------------------");
                student.DisplayStudentInfo();
                Console.WriteLine("------------------------------------");
            }
        }
    }
}
