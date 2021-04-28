using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadratic_Equation_Solver //Identifier: {_|a..z|A..Z}{_|a..z|A..Z|0..9}*
{
    class Program //{access modifier?} class {identifier}
    {
        public struct QuadtraticEquation
        {
            public double A; //{access modifier} {type} {identifier}
            public double B;
            public double C;
        }

        static void Main(string[] args)
        {
            QuadtraticEquation e = ReadEquation();

            double[] r = Solve(e);

            WriteResult(r);

            Console.ReadLine();
        }

        private static void WriteResult(double[] r)
        {
            if (r.Length == 0)
            {
                Console.WriteLine("Nincs megoldas");
            }

            else if (r.Length == 1)
            {
                Console.WriteLine("A megoldas: " + r[0]);
            }
            else
            {
                Console.WriteLine("A megoldasok: " + r[0] + ", " + r[1]);
            }
        }

        private static QuadtraticEquation ReadEquation()
        {
            QuadtraticEquation e = new QuadtraticEquation();

            e.A = Convert.ToDouble(Console.ReadLine());
            e.B = Convert.ToDouble(Console.ReadLine());
            e.C = Convert.ToDouble(Console.ReadLine());
            return e;
        }

        public static double Discriminant(QuadtraticEquation e)
        {
            return e.B * e.B - 4 * e.A * e.C;
        }

        public static double[] Solve(QuadtraticEquation e)
        {
            var d = Discriminant(e);
            if (d < 0)
            {
                return new double[0];
            }

            var x1 = ((-e.B) + Math.Sqrt(d)) / (2 * e.A);
            var x2 = ((-e.B) - Math.Sqrt(d)) / (2 * e.A);

            if (x1 == x2)
            {
                return new double[] { x1 };
            }

            return new double[] { x1, x2 };
        }
    }
}