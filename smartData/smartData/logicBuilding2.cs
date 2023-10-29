using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartData
{
    public class logicBuilding2
    {

        public static void Main(string[] args)
        {
           // string str2 = "11211";
            //Console.WriteLine(str2[0]);
            //Console.WriteLine(str2.Length);


            //for (int i = 0; i < str2.Length-1; i++)
            //{
            //    Console.WriteLine(str2);
            //    if (str2[i] == str2.Length-i+1)
            //    {
            //        Console.WriteLine(str2[i]);
            //        Console.WriteLine("no");
            //        Console.WriteLine(str2.Length - i + 1);
            //    }
            //    else
            //    {
            //        Console.WriteLine("yes");
            //    }
            //}

            string str2 = "11211";
            bool isPalindrome = true;

            for (int i = 0; i < str2.Length / 2; i++)
            {
                if (str2[i] != str2[str2.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }
            if (isPalindrome)
            {
                Console.WriteLine($"{str2} is a palindrome.");
            }
            else
            {
                Console.WriteLine($"{str2} is not a palindrome.");
            }






























            //char[] charArray = { 'H', 'e', 'l', 'l', 'o' };
            //int length = charArray.Length;

            //for (int i = 0; i < length / 2; i++)
            //{
            //    char temp = charArray[i];
            //    charArray[i] = charArray[length - i - 1];
            //    charArray[length - i - 1] = temp;
            //}

            //// Print the reversed array
            //foreach (char c in charArray)
            //{
            //    Console.Write(c);
            //}

            // Output: "olleH"

        }
    }
}
