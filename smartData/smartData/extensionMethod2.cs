using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartData
{

    interface base1
    {
        void hello();

    }

    class derived1 : base1
    {
        public void hello()
        {
            Console.WriteLine("hello i m inherit from base1 class");
        }
        public static void hi()
        {
            Console.WriteLine("hi im derived1 class");
        }
    }

    class derived2 : base1
    {

        public void hello()
        {
            Console.WriteLine("hello i m inherit from base1 class   ----------------");

        }
        public static void bye()
        {
            Console.WriteLine("bye im derived2 class");
        }
    }

    static class hello1
    {
        public static void goodMorning(this base1 a)
        {
            Console.WriteLine("good morning");
            a.hello();
        }

        public static void goodNight(this base1 b)
        {
            Console.WriteLine("good Night");
        }
    }
    public class extensionMethod2
    {


        public static void Main(string[] args)
        {
            derived1 d1 = new derived1();
            d1.goodMorning();

            derived2 d2 = new derived2();
            d2.goodMorning();
        }
    }
}

