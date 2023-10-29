using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    internal class subString
    {
        public static void Main(string[] args) {

            string name = "Achal4905l894l808";
            //Console.WriteLine(name.Substring(1));

            // verbatim literals
            string txt = @"The: \ character 'm "" is called  \\ backslash.";
            //Console.WriteLine(txt);


            var arr = name.Split('l');
            foreach (var item in arr)
            {
                //Console.WriteLine(item);
            }

            //arr.forEach(() =>
            //{
            // javascript
            //})

            int myInt = 10;
            double myDouble = 5.25;
            bool myBool = true;


            //Console.WriteLine(Convert.ToString(myInt));    // convert int to string
            //Console.WriteLine(Convert.ToDouble(myInt));    // convert int to double
            //Console.WriteLine(Convert.ToInt32(myDouble));  // convert double to int
            //Console.WriteLine(Convert.ToString(myBool));   // convert bool to string

        }
    }
}

