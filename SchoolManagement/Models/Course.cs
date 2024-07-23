using MM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolManagement.Models.School;

namespace SchoolManagement.Models
{
    internal class Course
    {
        private static Guid _id;
        private string _coursename;
        private int _credits;
        private Teacher _teacher;
        private List<Student> _courseStudents;
        private string _description;
        private string _schedule;
        private Status _status;
        private double _approvalScore;
        private double _minGPA;
        private List<Grade> _coursegrades;

        private static Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ShortID;

 
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

        public string Schedule
        {
            get
            {
                return _schedule;
            }
            set
            {
                _schedule = value;
            }
        }
        public Status ActualStatus
        {
            get
            {
                return _status;
            }
            set
            {

            _status = value; 
            }
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
        public List<Student> CourseStudents
        {
            get { return _courseStudents; }
            set { _courseStudents = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public double ApprovalScore
        {
            get { return _approvalScore; }
            set 
            {
                if (value < 1)
                {
                    throw new ArgumentException("Approval Score Can't be less than 1!");
                }
                if (value > 100)
                {
                    throw new ArgumentException("Approval Score Can't be higher than 100!");
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

        public List<Grade> CourseGrades
        {
            get
            {
                return _coursegrades;
            }
            set
            {
                _coursegrades = value;
            }
        }

        public Course( string NewCourseName, int newCredits, string newDescription, string newSchedule, double newApprovalScore, double newMinGPA, int newStatus)
        {
            _id = Guid.NewGuid();
            ShortID = GeneralFunctions.GetShortId(_id);
            _coursename = NewCourseName;
            _credits = newCredits;
            _description = newDescription;
            _approvalScore = newApprovalScore;
            _minGPA = newMinGPA;
            _schedule = newSchedule;
            _courseStudents = new List<Student>();
            _coursegrades = new List<Grade>();
            _status = (Status)newStatus;

        }

        public void EnrollStudnet(Student newStudent)
        {
            CourseStudents.Add(newStudent);
            newStudent.CreditsErned = newStudent.CreditsErned - Credits;
            Console.WriteLine($"Studnet {newStudent.FirstName} {newStudent.LastName} was Added To the Course {CourseName}!");

        }

        public void AddTeacher(Teacher newTeacher)
        {
            CourseTeacher = newTeacher;
            Console.WriteLine($"Teacher {newTeacher.FirstName} was Added To the Course {CourseName}!");
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine("Course ID         : " + ShortID);
            Console.WriteLine("Course Name       : " + CourseName);
            Console.WriteLine("Course Description: " + Description);
            Console.WriteLine("Schedule          : " + Schedule);
            Console.WriteLine("Status            : " + ActualStatus);
            Console.WriteLine("Credits           : " + Credits);
            Console.WriteLine("Approval Score    : " + ApprovalScore);
            Console.WriteLine("Min GPA           : " + MinGPA);
            Console.WriteLine("Teacher           : " + CourseTeacher.FirstName + " " + CourseTeacher.LastName);

            if (!CourseStudents.Any())
            {
                Console.WriteLine("Students          : N/A");
            } else {
                Console.WriteLine("Students          : ");
                Console.WriteLine("------------------------------------");
                foreach (Student student in CourseStudents)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                    Console.WriteLine("------------------------------------");
                } 
            }
        }

        public enum Status
        {
            Ready,
            Started,
            Finished,
            Close
        }

        public static string[] GetStatus()
        {
            string[] Status = Enum.GetNames(typeof(Status));
            return Status;
        }
    }
}
