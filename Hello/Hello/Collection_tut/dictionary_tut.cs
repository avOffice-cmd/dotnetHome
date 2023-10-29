using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello.Collection_tut
{
    public class dictionary_tut
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> d1 = new Dictionary<int, string>()
            {
                {0, "salil" },
                {12, "tubbu" }
            };

            // Insert
            d1.Add(1, "salil");
            d1.Add(4, "sahil");
            d1.Add(2, "achal");
            d1.Add(3, "dugu");

            // Modify
            d1[1] = "henry";


            // Remove
            //d1.Remove(1);  // remove whole pair using key
            //d1.Clear(); // removes all items


            // Iteration
            foreach (KeyValuePair<int, string> pair in d1)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }

            // OR
            foreach (var pair in d1)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }


            // **************
            // SortedList
            Console.WriteLine("--------------Sortedlist here------------");
            SortedList<int, string> sl = new SortedList<int, string>();

            sl.Add(3, "dugu");
            sl.Add(1, "salil");
            sl.Add(4, "sahil");
            sl.Add(2, "achal");

            foreach (KeyValuePair<int, string> pair in sl)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }








        }
    }
}
