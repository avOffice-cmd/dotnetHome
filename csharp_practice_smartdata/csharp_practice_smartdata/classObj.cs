using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_practice_smartdata
{
    public class classObj
    {
        int roll_no;
        string name;
        int age;
        int statndard;

        // constructor
        //public classObj()
        //{
        //    Console.WriteLine("i m default cons");
        //}

        // parameterized cons
        public classObj(int _rollno, string _name, int _age, int _statndard)
        {
            roll_no = _rollno;
            name = _name;
            age = _age;
            statndard = _statndard;
        }

        //public void set(int rollno, string name, int age, int standard)
        //{
        //    this.roll_no = roll_no;
        //    this.name = name;   
        //    this.age = age;
        //    this.statndard = standard;
        //}

        //public int get()
        //{
        //    Console.WriteLine("roll no is" + this.roll_no);
        //    Console.WriteLine("name is " + this.name);
        //    Console.WriteLine("age is " + this.age);
        //    return 1;
        //}
        public static void Main(string[] args)
        {
            //classObj obj = new classObj();
            //obj.set(20, "achal", 22, 4);

            //obj.get();

            // calling cons
            classObj c1 = new classObj(20,"achal",12,3);
            
        }
    }
}
