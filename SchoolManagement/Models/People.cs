using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    internal class People :School
    {
        private string _firstname;
        private string _lastname;
        private DateTime _birthdDate;
        private string _address;
        private string _phoneNo;

        public string FirstName
        {
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

        public People(string newFirstName, string newLastName, DateTime newBirthDate, string newAddress, string newPhoneNo)
        {
            _firstname = newFirstName;
            _lastname = newLastName;
            _birthdDate = newBirthDate;
            _address = newAddress;
            _phoneNo = newPhoneNo;
        }
    }
}
