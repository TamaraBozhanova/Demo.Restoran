using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ComplexNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber z1 = new ComplexNumber(-1, -1);
            Console.WriteLine("Комплексное число z1 = " + z1);

            Console.WriteLine();

            ComplexNumber z2 = new ComplexNumber(1, 2);
            Console.WriteLine("Комплексное число z2 = " + z2);

            Console.WriteLine();

            ComplexNumber z3 = z1 + z2;
            Console.WriteLine("Комплексное число z3 = ({0}) + ({1}) = {2} ", z1, z2, z3);

            Console.WriteLine();

            ComplexNumber z4 = z1 - z2;
            Console.WriteLine("Комплексное число z4 = ({0}) - ({1}) = {2}", z1, z2, z4);

            Console.WriteLine();

            ComplexNumber z5 = z1 * z2;
            Console.WriteLine("Комплексное число z5 = ({0})*({1}) = {2} ", z1, z2, z5);

            Console.WriteLine();

            ComplexNumber z6 = z1 / z2;
            Console.WriteLine("Комплексное число z6 = ({0})/({1}) = {2} ", z1, z2, z6);

            Console.WriteLine();

            Console.WriteLine("Модуль комплексного числа {0}, то есть, |{0}| = {1} ", z1, ComplexNumber.Mod(z1));

            Console.ReadKey();
        }
    }
}
