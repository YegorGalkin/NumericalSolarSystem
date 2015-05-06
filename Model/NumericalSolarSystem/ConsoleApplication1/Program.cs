using NumericalMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            var x = new EulerForward();
            var y = new EulerSemiImplicit();
            Console.WriteLine(x.SystemCoordinatesVector);
            Console.WriteLine(x.SystemImpulseVector);
            for (int i = 0; i < 10; i++)
            {
                x.NextStep();
                y.NextStep();
            }
                
            Console.WriteLine(x.SystemCoordinatesVector-y.SystemCoordinatesVector);
            Console.WriteLine(x.SystemImpulseVector-y.SystemImpulseVector);
            Console.ReadKey();
        }
    }
}
