using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello.Collection_tut
{
    internal class HashSet_tut
    {

        public static void Main(string[] args)
        {
            HashSet<int> h1 = new HashSet<int>();

            h1.Add(10);
            h1.Add(20);
            h1.Add(10);   // does not support duplicate elements
            h1.Add(30);


            foreach (int i in h1)
            {
                Console.WriteLine(i);
            }



        }
    }
}
