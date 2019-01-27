using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStructs;

namespace ProjectStructsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine();
            Time c = new Time(1,0, 0);
            Console.WriteLine(c);
            Console.WriteLine();

            TimePeriod b = new TimePeriod(5, 0, 0);
            Console.WriteLine(b);
            Console.WriteLine();

            var multiP = TimePeriod.Multiplication(b, 8);
            Console.WriteLine(multiP.ToString());

            var subP = TimePeriod.Minus(c, b);
            Console.WriteLine(subP.ToString());

            var sumP = TimePeriod.Plus(c, b);
            Console.WriteLine(sumP.ToString());
            Console.WriteLine();

            var sub = Time.Minus(c, b);
            Console.WriteLine(sub.ToString());

            var sum = Time.Plus(c, b);
            Console.WriteLine(sum.ToString());

        }


    }
}
