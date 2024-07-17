﻿using SchoolManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SchoolManagement.Models
{
    internal class Student : School
    {
        private int _id;
        private string _firstname;
        private string _lastname;
        private DateTime _birthdDate;
        private string _address;
        private string _phoneNo;
        private DateTime _enrrollmentDate;
        private Major _major;
        private double _gpa;
        private int _creditsErned;

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
        public string FirstName { 
            get 
            {
                return _firstname;
            } 
            set 
            {
                _firstname = value; 
            } 
        }
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return _birthdDate;
            }
            set
            {
                _birthdDate = value;
            }
        }
        public string Addres
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return _phoneNo;
            }
            set
            {
                _phoneNo = value;
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

        public Student(int id, string newFirstName, string newLastName, DateTime newBirthDate, string newAddress, string newPhoneNo, double newGPA, int newMajor) 
        {
            Id = id;
            _firstname = newFirstName;
            _lastname = newLastName;
            BirthDate = newBirthDate;
            _address = newAddress;
            _phoneNo = newPhoneNo;
            _gpa = newGPA;
            EnrrollmentDate = DateTime.Now; 
            StudentMajor = (Major)newMajor;
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
            CreditsErned = Value;
        }
    }

}
