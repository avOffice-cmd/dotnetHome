using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_tut
{
    public class Class1
    {
        public string name = "dudu";
        public int age = 5;
    }
    public class List_tut
    {
        
        public static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1,2,3,5,56};

            // Insert
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(14);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            Console.WriteLine(list.Count);



            // Access
            //Console.WriteLine(list[2]);

            // delete
            //list.RemoveAt(3); // remove by index
            //list.Remove(1); // remove element directly


            // Modify
            //list[1] = 10;   // 2 3  --> 2 10
            //list.Insert(1, 10);  // 2 3 --> 2 10 3


            // Iterate
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }

            var foundItem = list.FindAll((item) =>
            {
                return item < 10;
            });

            Console.WriteLine(foundItem);
            foreach (int item in foundItem)
            {
                Console.WriteLine(item);
            }


            // List of objects
            List<Class1> classList = new List<Class1>();

            Class1 salil = new Class1();
            classList.Add(salil);

            foreach (Class1 item in classList)
            {
                Console.WriteLine($"NAme is {item.name} Age is {item.age}");
            }



        }
    }
}
