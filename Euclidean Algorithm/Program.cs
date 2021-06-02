using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidean_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = ReadNumber();
            int b = ReadNumber();

            while (a != b)
            {
                if (a < b)
                {
                    b = b - a;
                }
                else
                {
                    a = a - b;
                }
            }

            Console.WriteLine(a);
            Console.ReadLine();
        }

        public static int[] InputArray()
        {
            int n = ReadNumber("Hány számot szeretnél megadni? ");
            int[] numbers = new int[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = ReadNumber(i + 1 + ". szám: ");
            }

            return numbers;
        }

        public static int ReadNumber(string message = null)
        {
            Console.Write(message ?? "Kérlek adj meg egy számot! ");
            while (true)
            {
                int number;
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Számot adj meg!");
                }
            }
        }
    }
}
