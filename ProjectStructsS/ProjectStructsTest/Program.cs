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
            Time a = new Time();
            Console.WriteLine(a);
            Console.WriteLine();

            Time b = new Time(3);
            Console.WriteLine(b);
            Console.WriteLine();

            Time x = new Time();
            long sum = x.MathTime('+', a, b);
            Console.WriteLine(sum);

            Console.WriteLine();
            Time c = new Time(5, 24);
            Console.WriteLine(c);
            Console.WriteLine();

            Time d = new Time(4, 25, 30);
            Console.WriteLine(d);
            Console.WriteLine();

            TimePeriod aP = new TimePeriod();
            Console.WriteLine(aP);
            Console.WriteLine();

            TimePeriod bP = new TimePeriod(3, 5);
            Console.WriteLine(bP);
            Console.WriteLine();

            TimePeriod cP = new TimePeriod(5, 3, 8, 6);
            Console.WriteLine(cP);
            Console.WriteLine();

            TimePeriod dP = new TimePeriod(5, 3, 8, 59, 9,3);
            Console.WriteLine(dP);
            Console.WriteLine();
        }
    }
}
