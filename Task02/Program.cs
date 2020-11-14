using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона (1; 10000] создать массив целых чисел B,
 * в котором на каждой позиции стоит ближайшая степень двойки меньшая значения из массива A у той же позиции.
 * Например, A = {30, 100, 300} B = {16, 64, 256}.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 3 10 20
 *
 * Пример выходных данных:
 * 2 8 16
 */

namespace Task02
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";
        
       
        static int[] ReadFile(string path)
        {
            string items = File.ReadAllText(path);
            string[] values = items.Split(' ');
            int[] result = new int[values.Length];
            int i = 0;
            foreach (string item in values)
            {
                int.TryParse(item, out result[i++]);
            }
            return result;
        }
        
        static bool CheckArray(int[] array)
        {
            foreach (int item in array)
            {
                if (item < 2 || item > 10000)
                {
                    return false;
                }
            }
            return true;
        }
        
        static int[] ConvertArray(int[] array)
        {
            int[] powersArray = new int[array.Length];
            int i = 0;
            foreach (int item in array)
            {
                int pow = 1;
                while (item > pow * 2)
                {
                    pow *= 2;
                }
                powersArray[i++] = pow;
            }
            return powersArray;
        }


        static void WriteFile(string path, int[] array)
        {
            string result = String.Empty;
            foreach (int item in array)
            {
                result += $"{item} ";
            }
            File.WriteAllText(path, result);
        }

        // you do not need to fill your file manually, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();
            
            int[] A;
            int[] B;
            try
            {
                A = ReadFile(inputPath);
                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect Input");
                    return;
                }
                B = ConvertArray(A);
                WriteFile(outputPath, B);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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