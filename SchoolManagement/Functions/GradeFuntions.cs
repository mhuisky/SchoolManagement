using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Functions
{
    internal class GradeFuntions
    {
        public static void GradeManagement(int Selection)
        {
            switch (Selection)
            {
                case 1:
                    Console.WriteLine("test1");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("test2");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("test3");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
    }
}
