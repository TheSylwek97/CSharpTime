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
            /*
            Console.WriteLine();
            Time c = new Time(5, 24);
            Console.WriteLine(c);
            Console.WriteLine();

            TimePeriod dP = new TimePeriod(22,36,59);
            Console.WriteLine(dP);
            Console.WriteLine();
            */
            var sampleTime = new Time(12);
            var sampleTimePeriod = new TimePeriod(0, 15, 0);

            var sum = Time.Plus(sampleTime, sampleTimePeriod);
            Console.WriteLine(sum.ToString());

        }


    }
}
