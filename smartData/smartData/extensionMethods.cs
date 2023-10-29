using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace smartData
{

    // static class

    static class hello
    {

        public static bool IsGreaterThan(this int a, int value)
        {
            return a > value;
        }
        public static void Fun3(this extensionMethods a)
        {
            Console.WriteLine("i m fun 3 extension method" + a.name);
        }

        public static void Fun4(this extensionMethods b)
        {
            Console.WriteLine("I m fun 4 extension method");
            
        }

      

    }
    public class extensionMethods
    {
        public string name = "salil";
        int password = 1234;
       public void fun1()
        {
            Console.WriteLine("hello im fun1");
        }

        public void fun2()
        {
            Console.WriteLine("hello i m fun2");
        }

       

       
        public static void Main(string[] args)
        {
            extensionMethods em = new extensionMethods();
            int i = 20;
            bool result = i.IsGreaterThan(60);

            //em.fun1();
            //em.fun2();
            em.Fun3();
            em.Fun4();




        }
    }
}
