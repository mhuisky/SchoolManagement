using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    internal class Grade : School
    {
        private static Guid _id;
        private Course _course;
        private Student _student;
        private double _score;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Course Course
        {
            get
            {
                return _course;
            }
            set
            {
                _course = value;
            }
        }

        public Student Student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
            }
        }

        public double Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Score can't be negative!");
                }
                _score = value;
            }
        }
        public Grade(Course newCourse, Student newStudent, double Grade)
        {
            _id = Guid.NewGuid();
            _course = newCourse;
            _student = newStudent;
            _score = Grade;
        }


    }
}
