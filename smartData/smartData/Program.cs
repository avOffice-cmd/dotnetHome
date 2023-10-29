using System.Collections.Generic;
using System.Data.SqlTypes;

namespace smartData
{
    public class Program
    {
        static void Main(string[] args)
        {
            // string methods ToUpper

            string name = "hello i m achal verma";
            name = name.ToUpper();
           // Console.WriteLine(name);

            // string method ToLower

            string name1 = "hello i m salil";
            name1 = name1.ToLower();
           // Console.WriteLine(name1);

            // string method Trim

            string name2 = "     hello      ";
            name2 = name2.Trim();
            //Console.WriteLine(name2);

            //String.Contains() ->
            //Contains method return --[ bool ]-- value,it checks whether specified string or character exist in string or not.

            string name3 = "Hello I am harry";
            bool b = name3.Contains("I");
            //Console.WriteLine(b);


            // String.ToCharArray() - Convert a string to array of character.

            string myName = "myName is SHREESH";
            char[] charArray = myName.ToCharArray();
            foreach (char ch in charArray)
            {
                //Console.WriteLine(c);
            }

            //String.Substring() - substring method returns substring of a string.

            string name5 = "hello i m achal";
            //string c = name5.Substring(name5.Length - 1);   
            string c = name5.Substring(0,9);
            string c2 = name5.Substring(5);
            // Console.WriteLine(c);


            //String.StartsWith() - Startswith method checks whether the first character of a string
            //is same as specified character.It returns bool value.

            string name6 = "yeye dhd kdnkdn";
            bool x = name6.StartsWith("yeye");
            //Console.WriteLine(x);


            // String.Split() - Split function splits the string on the supplied value.It return the array of string.
            string name7 = "heelo, i- m a good girl";
            string[] s = name7.Split('-');
            foreach (string s2 in s) {
                Console.WriteLine(s2);
            }

            //Concat: Concatenates two or more strings.

            string str1 = "hello";
            string str2 = "bolo";

            string result = string.Concat(str1, str2);
            Console.WriteLine(result);

            // replace
            string str = "Hello, World!";
            string replaced = str.Replace("World", "Universe"); // "Hello, Universe!"

            // compare
            string str11 = "apple";
            string str22 = "banana";
            int result1 = string.Compare(str1, str2); // <0 (str1 is less than str2)
            Console.WriteLine(result1);


        }
    }
}