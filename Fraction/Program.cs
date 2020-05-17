using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"0 3\5 - 1 1\2 + 1 3\5 + 1 1\2";
            Console.WriteLine(file);
            Console.WriteLine();
            var frac = new Fraction(file, file);
            var res = frac.AddInFraction();
            Console.WriteLine(res);


        }
    }
}
