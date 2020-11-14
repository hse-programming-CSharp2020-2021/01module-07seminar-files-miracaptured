using System;
using System.IO;
using System.Text;

/*
 * По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L.
 * Количество элементов в массивах совпадает.
 * На местах неотрицательных элементов в массиве A
 * в массиве L стоят значения true, на месте отрицательных – false.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 0 -1
 *
 * Пример выходных данных:
 * true false
 */

namespace _01_07_Files
{
    class Program
    {
         private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";
        
        static int[] ReadFile(string path)
        {
            string[] countStr = File.ReadAllText(path).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] values = new int[countStr.Length];
            for (int i = 0; i < values.Length; ++i)
            {
                values[i] = int.Parse(countStr[i]);
            }
            return values;
        }

        static bool CheckArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 10 || array[i] < -10)
                {
                    return false;
                }
            }
            return true;
        }
        
        static bool[] IntToBoolArray(int[] array)
        {
            bool[] length = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    length[i] = false;
                }
                else
                {
                    length[i] = true;
                }
            }
            return length;
        }
        
        static void WriteFile(string path, bool[] array)
        {
            StringBuilder text = new StringBuilder();
            foreach (var item in array)
            {
                text.Append(item.ToString().ToLower()).Append(" ");
            }
            File.WriteAllText(outputPath, text.ToString());
        }

        // you do not need to fill your file, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();
            
            int[] A;
            bool[] L;
            
            try
            {
                A = ReadFile(inputPath);
                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect Input");
                    return;
                }
                L = IntToBoolArray(A);
                WriteFile(outputPath, L);
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect Input");
                Console.WriteLine(e.Message);
            }
            
            // do not touch
            ConsoleOutput();
        }

        #region Testing methods for Github Classroom, do not touch!

        static void FillFile()
        {
            try
            {
                File.WriteAllText(inputPath, Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsoleOutput()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}