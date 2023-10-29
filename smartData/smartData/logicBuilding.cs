using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace smartData
{
    public class logicBuilding
    {
        //find odd and even element in an array and seprate them in new array


        public static void Main(string[] args)
        {
            int[] array = { 2, 5, 10, 15, 20,55,77,99 };
            int[] evenarr = new int[10];
            int[] oddarr = new int[10];

            int k = 0;
            int j = 0;


           // Console.WriteLine("Even or Odd:");

            foreach (int number in array)
            {
                if (number % 2 == 0)
                {
                    //Console.WriteLine($"{number} is an even number.");
                    evenarr[k] = number;
                    k++;
                  
                }
                else
                {
                    //Console.WriteLine($"{number} is an odd number.");
                    oddarr[j] = number;
                    j++;
                  
                }
            }

            foreach (var item in oddarr)
            {
               // Console.WriteLine(item);
            }


            ///////////////////////////////////////////////////////////////////////////////

            // In string remove the next duplicate element
            string input = "hello i am achal achal i am ";
            string[] words = input.Split(' ');
            

            //////////////////////////////////////////////////////////////////

            // remove numeric value


            string r = "1234abcd";
            string result = RemoveNumericCharacters(r);
            //Console.WriteLine(result); // Output: "abcd"

            static string RemoveNumericCharacters(string r)
            {
                // Create a new string without numeric characters
                string result = "";
                foreach (char c in r)
                {
                    if (!char.IsDigit(c))
                    {
                        //result += c;
                    }
                }
                return result;
            }



         // using ASCII VALUE
         
            string str = "123657765894agfjfkygfluglbdc";
            byte[] arr = Encoding.ASCII.GetBytes(str);
            string temp = "";

            foreach (var item in arr)
            {
                // Console.WriteLine(" {0} = {1}  ",  (char)item, item);

                if (item >= 48 && item <= 57)
                {
                   // Console.WriteLine((char)item);
                }
                else
                {
                    //Console.WriteLine((char)item);
                    temp += (char)item;
                }
            }
           // Console.WriteLine(temp);





            //////////////////////////////////////////////////////////////////////////////////////
            // reverswe the char arrray and convert into a string

            static string Reverse(string Input)
            {

                // Converting string to character array 
                char[] charArray = Input.ToCharArray();

                // Declaring an empty string
                string reversedString = String.Empty;

                // Iterating the each character from right to left 
                for (int i = charArray.Length - 1; i > -1; i--)
                {

                    // Append each character to the reversedstring.
                    reversedString += charArray[i];
                }

                // Return the reversed string.
                return reversedString;
            }

            // Console.WriteLine(Reverse("abcd"));




            //////////////////////////////////////////////////////////////////////////////////////////
            // check palindrome number using delegates

           // Console.WriteLine("Enter palindrome number");
            int num = int.Parse(Console.ReadLine());
            int rem;
            int result1 = 0;
            int temp1 = num;
            //Console.WriteLine(temp1);
            while (num != 0)
            {
                rem = num % 10;
                result1 = result1 * 10 + rem;
                num = num / 10;
            }

            num = temp1;
           // Console.WriteLine(num);
            if (num == result1)
            {
               // Console.WriteLine("Plaindrome number");
            }
            else
            {
               // Console.WriteLine("does not plaindrome number");
            }

            ////////////////////////////////////////////////
            ///



           


        }
    }
}
