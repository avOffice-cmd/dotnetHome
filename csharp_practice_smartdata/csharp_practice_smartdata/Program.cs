using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice_smartdata
{
    public class Program
    {

        // method 
        public void show()
        {
            Console.WriteLine("hello i m non static method");
            Console.WriteLine("yoyooyoyoyo");
        }

        // static method

        public static void show1()
        {
            Console.WriteLine("hello im static method");
        }


        // parameterized method
        public static int add(int x, int y) {
          return x + y; 
        }

        // string method

        public static string showName( string name)
        {
            return name;
        }


        public static void showdetail(string detail , int age) {
            Console.WriteLine("the detail is : " + detail, age);
        }


        public static int sub(int x, int y) { 
          int result = x - y;
            return result;
        }
        static void Main(string[] args)
        {
            Program  p1 = new Program();
            p1.show();

            Program.add(1,2);
            Program.show1();
            Program.showName("achal");
            //Program.showdetail("yes ok", 20);
            Program.showdetail(age: 20, detail: "ok");

            int b = Program.sub(1, 2);
            Console.WriteLine(b);

            int a = 20;
            int c = a + b;
            Console.WriteLine(c);
        }
    }
}
