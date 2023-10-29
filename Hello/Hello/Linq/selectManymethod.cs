using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello.Linq
{
    internal class selectManymethod
    {

        static void Main(string[] args)
        {
            List<string> strList = new List<string>() { "salil", "Achal"};
            
            var methodResult = strList.SelectMany(x => x); 
            
            // or

            var queryResult = (from rec in strList
                               from ch in rec
                               select ch).ToList();
        }
    }
}
