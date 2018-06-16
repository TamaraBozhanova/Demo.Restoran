using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using System.Threading.Tasks;

namespace maxSentence2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your story:");
            string story = Console.ReadLine();
            story = Regex.Replace(story, @"\s+", " ");
            story = story.Replace(" ,", ",");
          
            // создаем массив строк, разбивая исходный текст по точке, восклицательному знаку или вопросительному;
            string[] array = story.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            //создаем целочисленный массив, элементы которого - количество слов в соответствующих предложениях; 
            int[] nWords = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array[i].Trim();
                nWords[i] = (array[i].Split()).Length;               
            }
            // Находим максимальный элемент целочисленного массива и его индекс;
            int max = nWords[0];
            int index = 0;
            for (int j = 1; j < array.Length; j++)
            {
                if (nWords[j] > max)
                {
                    max = nWords[j];
                    index = j;
                }
            }
            // Выводим на консоль предложение с наибольшим количеством слов.
            Console.WriteLine(array[index]);

            Console.ReadKey();
        }
    }
}
