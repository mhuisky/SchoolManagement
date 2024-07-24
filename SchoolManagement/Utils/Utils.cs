using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Utils
{
    public class IDGenerator
    {
        public int currentID;

        public IDGenerator()
        {
            currentID = 0;
        }

        public int GenerateID()
        {
            return ++currentID;
        }
    }

    public class  Utils()
    {
        public static DateTime GetDate(string Date)
        {
            string[] fullDate = Date.Split('/');
            if (fullDate.Length != 3)
            {
                throw new ArgumentException("The Date Has wrong Format!");
            }
            int month = int.Parse(fullDate[0]);
            int day = int.Parse(fullDate[1]); 
            int year = int.Parse(fullDate[2]);
            DateTime date = new DateTime(year, month, day);
            return date;
        }
    }
    
}
