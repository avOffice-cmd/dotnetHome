using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice_smartdata
{
    public class staticCons
    {

        public static string name;
        public static int age;

        // static cons

        static staticCons()
        {
            name = "achal";
            age = 10;
        }


        // default cons
        public staticCons()
        {
            Console.WriteLine("i m default cons");
        }
        public static void main(string[] args)
        {
            staticCons c = new staticCons();
        }
    }
}
