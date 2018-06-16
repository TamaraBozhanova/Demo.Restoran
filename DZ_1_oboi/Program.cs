using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp39
{
    class Program
    {
        static void Main(string[] args)
        {
            double roomWidth, roomLength, roomHeight; //ширина длина и высота комнаты
            double rollLength, rollWidth, step; //параметры обоев

            Console.WriteLine("Enter roomWidth:");
            roomWidth = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter roomLength:");
            roomLength = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter roomHeight:");
            roomHeight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter rollLength:");
            rollLength = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter rollWidth:");
            rollWidth = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter step:");
            step = Convert.ToDouble(Console.ReadLine());
            
            double roomPerimeter = (roomWidth + roomLength) * 2;//периметр комнаты

            int numberBandsInRoom;//количество полос для поклейки комнаты;
            if (roomPerimeter % rollWidth != 0)
            {
                numberBandsInRoom = (int)(roomPerimeter / rollWidth) + 1;
            }
            else { numberBandsInRoom = (int)(roomPerimeter / rollWidth); }
            

            int numberBandsInRoll;//количество полос с одного рулона;            
            numberBandsInRoll = 1 + (int)((rollLength - roomHeight) / (roomHeight + step));             
           
            
            int numberRolls;//количество рулонов для поклейки комнаты;
            if (numberBandsInRoom % numberBandsInRoll != 0) { numberRolls = numberBandsInRoom / numberBandsInRoll + 1; }
            else { numberRolls = numberBandsInRoom / numberBandsInRoll; }

            double roomArea = roomPerimeter * roomHeight;// площадь поверхности
            double rollsArea = rollLength * rollWidth * numberRolls;//площадь обоев
            double remainder = rollsArea - roomArea;//площадь остатков
            double percent = (remainder / rollsArea) * 100;//процент потерь обоев

            Console.WriteLine("Number of rolls: " + numberRolls);
            Console.WriteLine("Remainder: " + Math.Round(remainder, 2) + " sq.m.");
            Console.WriteLine("Per cent of the roll losses: " + Math.Round(percent, 2)+" %");

            Console.ReadKey();

        }
    }
}
