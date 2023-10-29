using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello.Linq
{
    public class program
    {
        static void Main(string[] args) {
        
            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9,10};
            
            IEnumerable<int> querySyntax = from obj in list
                                           where obj > 2
                                           select obj;


        
        }
    }
}
