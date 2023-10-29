using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice_smartdata
{
    internal class stringPractice
    {
        public static void Main(string[] args)
        {
            string s1 = "   Salil DEogade And His Girl Anchal  ";
            string s2 = "salil.deogade@gmail.com";
            //Console.WriteLine(s1);
            //Console.WriteLine(s1.Trim());

            //Console.WriteLine(s1.Substring(4));
            //Console.WriteLine(s1.Substring(4, 7));

            string[] arr = s2.Split('@');
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
            Array.Sort(arr);
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);

            string joinedString = string.Join("@", arr);
            Console.WriteLine(joinedString);
        }
        

        

    }
}
