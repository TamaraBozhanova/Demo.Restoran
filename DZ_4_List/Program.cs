using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Dictionary
{
    public interface IList
    {
        void add(int el);
        void SortUp();
        void SortDown();
        int FindMinElement();
        int FindMaxElement();
        string toString();
        int length();
        void reverce();
    }
    public class RealezIList:IList
    {
        int index = 0;
        int[] array = new int[4];

        public void add(int el)
        {
            if (index == array.Length)
            {
                int length = array.Length;
                int[] newArr = new int[length * 2];
                for (int i = 0; i < index; i++)
                {
                    newArr[i] = array[i];
                }
                array = newArr;
                array[index] = el;
                index++;
            } else
            {
                array[index] = el;
                index++;
            }
        }

        public void init(int[] init)
        {
            for (int i = 0; i < init.Length; i++)
            {
                add(init[i]);
            }
        }

        public string toString()
        {
            string str = "";
            for (int i = 0; i < index; i++){
                str += array[i] + " ";
            }
            return str;
        }

        public void  SortUp()
        {
            int tmp;
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j < index; j++)
                {
                    if (array[j] > array[i])
                    {
                        tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }
               
        }

        public void SortDown()
        {
            int tmp;
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j < index; j++)
                {
                    if (array[j] < array[i])
                    {
                        tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }
                }
            }

        }

        public int length ()
        {
            return index;
        }

        public int FindMinElement()
        {
            int min = array[0];
            for (int i = 1; i < index; i++)
            {
              if(array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public int FindMaxElement()
        {
            int max = array[0];
            for (int i = 1; i < index; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public void reverce()
        {
            int[] newArray = new int[array.Length];
            for (int i = index; i > 0; i--)
            {
                newArray[index - i] = array[i - 1];
            }
            array = newArray;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            RealezIList list = new RealezIList();
            int[] init = { 1, 5, 9, 7, 82, 5, 5 };

            list.init(init);
            Console.WriteLine("Список: " + list.toString());

            list.reverce();
            Console.WriteLine("Реверс списка: "+list.toString());

            list.SortUp();
            Console.WriteLine("Сортировка от меньшего к большему: "+list.toString());

            list.SortDown();
            Console.WriteLine("Сортировка от большего к меньшему: " + list.toString());

            Console.WriteLine("max = " + list.FindMaxElement());

            Console.WriteLine("min = " + list.FindMinElement());


            /*        List<int> list = new List<int>();
                    int[] init = { 1, 5, 9, 7, 82, 5, 5 };

                    for(int i = 0; i < init.Length; i++)
                    {
                        list.Add(init[i]);
                    }
                    foreach (int i in list)
                      Console.Write(i + " ");
            */
            Console.ReadKey();
        }
    }
}
