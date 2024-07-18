using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolManagement.Models.School;

namespace SchoolManagement.Models
{
    internal class Teacher : People
    {
        private int _id;
        private DateTime _hireDate;
        private string _department;
        private string _specialization;
        private decimal _salary;

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
        public DateTime HireDate
        {
            get
            {
                return _hireDate;
            }
            set
            {
                _hireDate = value;
            }
        }
        public string Department
        {
            get
            {
                return _department; 
            }
            set
            {
                _department = value;
            } 
        }
        public string Specialization
        {
            get
            {
                return _specialization;
            }
            set
            {
                _specialization = value;
            }
        }
        public decimal Salary 
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary can't be negative!");
                }
                _salary = value;
            }
        }

        public Teacher(int id, string newFirstName, string newLastName, DateTime newBirthDate, string newAddress, string newPhoneNo,string newDepartment , string newSpecialization, decimal newSalary) : base(newFirstName, newLastName, newBirthDate, newAddress, newPhoneNo)
        {
            _id = id;
            _hireDate = DateTime.Now;
            _department = newDepartment;
            _specialization = newSpecialization;
            _salary = newSalary;
        }

        public void DisplayTeacherInfo()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("First Name: " + FirstName);
            Console.WriteLine("Birth Date: " + BirthDate.ToString("d"));
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("Specialization: " + Specialization);
            Console.WriteLine("HiretDate: " + HireDate.ToString("d"));
            Console.WriteLine("Salary: " + Salary);
        }

    }

}
