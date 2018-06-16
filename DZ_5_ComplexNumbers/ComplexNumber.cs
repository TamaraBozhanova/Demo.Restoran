using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ComplexNumber
{
    class ComplexNumber
    {
        private double _a;
        private double _b;       
        public double  Distvitelnaya{ get {return  _a; } set { _a = value; }  }
        public double Mnimaya { get { return _b; } set { _b=value; } }
        public char I = 'i';
                   
        public ComplexNumber(double a, double b)
        {
            Distvitelnaya = a;
            Mnimaya = b;
        }

        public override string ToString()
        {
            string res = "";

            if (Distvitelnaya == 0 && Mnimaya == 0) { res = $"0"; } 
            else if (Mnimaya == 1 && Distvitelnaya == 0) { res = $"{I}"; }
            else if (Mnimaya == -1 && Distvitelnaya == 0) { res = $"-{I}"; }
            else if (Distvitelnaya != 0 && Mnimaya == 0) { res = $"{Distvitelnaya}"; }
            else if (Mnimaya == -1) { res = $"{Distvitelnaya} - {I}"; }
            else if (Mnimaya == 1) { res = $"{Distvitelnaya} + {I}"; }
            else if (Mnimaya > 0 && Mnimaya != 1) { res = $"{Distvitelnaya} + {Mnimaya}{I}"; }
            else if (Mnimaya < 0 && Mnimaya != -1) { res = $"{Distvitelnaya} - {Mnimaya * (-1)}{I}"; }
                      
            return res; 
        }

        public static ComplexNumber operator +(ComplexNumber z1, ComplexNumber z2)
        {
            return new ComplexNumber(z1._a +z2._a, z1._b + z2._b);
        }
        public static ComplexNumber operator -(ComplexNumber z1, ComplexNumber z2)
        {
            return new ComplexNumber(z1._a - z2._a, z1._b - z2._b);
        }
        public static ComplexNumber operator *(ComplexNumber z1, ComplexNumber z2)// (z1._a +z1._bi)(z2._a +z2._bi)
        {
            return new ComplexNumber(z1._a * z2._a -z1._b * z2._b, z1._a*z2._b + z1._b * z2._a);
        }
        public static ComplexNumber operator /(ComplexNumber z1, ComplexNumber z2)// [(z1._a +z1._bi)(z2._a -z2._bi)]:[(z2._a +z2._bi)(z2._a -z2._bi)]
        {
            return new ComplexNumber((z1._a * z2._a + z1._b * z2._b)/(z2._a * z2._a + z2._b * z2._b), 
                                     (-z1._a * z2._b + z1._b * z2._a)/(z2._a * z2._a + z2._b * z2._b));
        }
        public static double num;

        public static double  Mod(ComplexNumber z)
        {
            return num = Math.Sqrt(z._a * z._a + z._b * z._b);
        }







        /*public override string ToString()
        {
            return Chislitel > Znamenatel ?
                $"{Chislitel / Znamenatel}+{Chislitel % Znamenatel } / {Znamenatel }" :
                $"{Chislitel} / {Znamenatel}";
        }
        public static Fract operator +(Fract a, Fract b)// передача параметров происходит по значению не по ссылке
        {
            return new Fract(a._ch * b._zn + b._ch * a._zn, a._zn * b._zn);
        }*/
    }
}
