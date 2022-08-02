using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace Table
{

   
    class Program
    {
        static string Fileneme = Directory.GetCurrentDirectory() + "\\sorted.txt"; 
        static public Stopwatch stopwatch = new Stopwatch();
        static public void SortingBySelection(int[] array) {
            long freq3 = Stopwatch.Frequency;
            stopwatch.Restart();    
            int index;
            for (int i = 0; i < array.Length; i++)
            {
                index = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] > array[index]) {
                        index = j;
                    }
                }
                if (array[index] == array[i]) 
                {
                    continue;
                }
                int temp = array[i];
                array[i] = array[index];
                array[index] = temp;              
            }
            for (int d = 0; d < array.Length; d++)
            {
                Console.Write(array[d] + " ");
            }
            Console.WriteLine(" ");
            stopwatch.Stop();
            double sec3 = (double)stopwatch.ElapsedTicks / freq3;
            Console.WriteLine(new String('=', 120));
            Console.WriteLine($"Время работы сортировки в секундах:{sec3}");
            Console.WriteLine(new String('=', 120));
            using (StreamWriter strem1 = new StreamWriter(Fileneme, true))
            {
                strem1.Write($"\n|Отсортированный массив меетодом Выбора| \n");
                for (int i = 0; i < array.Length; i++)
                {
                    strem1.Write(array[i] + " ");
                }
            }
        }

        static public void InsertionSort(int[] array) {
            long freq5 = Stopwatch.Frequency;
            stopwatch.Restart();
            int index;
            int currentNumver;
            for (int i = 0; i < array.Length; i++) 
            {
                index = i;
                currentNumver = array[i];
                while (index > 0 && currentNumver > array[index - 1]) 
                {
                    array[index] = array[index - 1];
                    index--;
                }
                array[index] = currentNumver;
            }
            for (int i = 0; i < array.Length; i++) {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine(" ");
            stopwatch.Stop();
            double sec5 = (double)stopwatch.ElapsedTicks / freq5;
            Console.WriteLine(new String('=', 120));
            Console.WriteLine($"Время работы сортировки в секундах:{sec5}");
            Console.WriteLine(new String('=', 120));
            using (StreamWriter strem2 = new StreamWriter(Fileneme, true))
            {
                strem2.Write("\n|Отсортированный массив меетодом Вставок| \n");
                for (int i = 0; i < array.Length; i++)
                {
                    strem2.Write(array[i] + " ");
                }
            }
        }
        static public void BubbleSort(int[] array) {
            long freq4 = Stopwatch.Frequency;
            stopwatch.Restart();
            int temp;
            for (int i = 0; i < array.Length; i++) 
            {
                for (int j = 0; j < array.Length - 1; j++) 
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
            for (int i = 0; i < array.Length; i++) 
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine(" ");
            stopwatch.Stop();
            double sec4 = (double)stopwatch.ElapsedTicks / freq4;
            Console.WriteLine(new String('=', 120));
            Console.WriteLine($"Время работы сортировки в секундах:{sec4}");
            Console.WriteLine(new String('=', 120));
            using (StreamWriter strem3 = new StreamWriter(Fileneme, true))
            {
                strem3.Write("\n|Отсортированный массив методом Пузырька| \n");
                for (int i = 0; i < array.Length; i++)
                {
                    strem3.Write(array[i] + " ");
                }
            }
        }
        static public void ShellSort(int[] array)
        {
            long freq1 = Stopwatch.Frequency;
            stopwatch.Restart();
            int j;
            int step = array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (array.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (array[j] <  array[j + step]))
                    {
                        int tmp = array[j];
                        array[j] = array[j + step];
                        array[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine(" ");
            stopwatch.Stop();
            double sec = (double)stopwatch.ElapsedTicks / freq1;
            Console.WriteLine(new String('=', 120));
            Console.WriteLine($"Время работы сортировки в секундах:{sec}");
            Console.WriteLine(new String('=', 120));
            using (StreamWriter strem4 = new StreamWriter(Fileneme, true))
            {
                strem4.Write("\n|Отсортированный массив меетодом Шелла| \n");
                for (int i = 0; i < array.Length; i++)
                {
                    strem4.Write(array[i] + " ");
                }
            }
        }

        static void Swap(int[] array, int i, int j)
        {
            int glass = array[i];
            array[i] = array[j];
            array[j] = glass;
        }

        static public void ShakerSort(int[] array)
        {           
            long freq2 = Stopwatch.Frequency;
            stopwatch.Restart();
            int left = 0,
                right = array.Length - 1;
            long count_switch = 0, //счетчик обменов
                count_compare = 0;//счетчик сравнений    

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    count_compare++;
                    if (array[i] < array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        count_switch++;
                    }
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count_compare++;
                    if (array[i - 1] < array[i])
                    {
                        Swap(array, i - 1, i);
                        count_switch++;
                    }
                }
                left++;
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            stopwatch.Stop();
            double sec2 = (double)stopwatch.ElapsedTicks / freq2;
            Console.WriteLine(new String('=', 120));
            Console.WriteLine($"Время работы сортировки в секундах:{sec2}");
            Console.WriteLine(new String('=', 120));
            using (StreamWriter strem5 = new StreamWriter(Fileneme, true))
            {
                strem5.Write("\n|Отсортированный массив меетодом Шейкера| \n");
                for (int i = 0; i < array.Length; i++)
                {
                    strem5.Write(array[i] + " ");
                }
            }

        }
        
        
        private static void Main()
        {
            Console.WriteLine("Исходный массив без сортировки|");
            Console.WriteLine(new String('=', 120));
            int[] array = new int[1000];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++) {
               array[i] = rand.Next(0, 1000);
                Console.Write(array[i]);
            }
            Console.WriteLine(new String('=',120));
            Console.WriteLine("Сортировка массива Выбором");
            SortingBySelection(array);
            Console.WriteLine(new String('=', 120));
            Console.WriteLine("Сортировка массива Вставками");
            InsertionSort(array);
            Console.WriteLine(new String('=', 120));
            Console.WriteLine("Сортировка массива Пузырьком");
            BubbleSort(array);
            Console.WriteLine(new String('=', 120));
            Console.WriteLine("Сортировка Шелла");
            ShellSort(array);
            Console.WriteLine(new String('=', 120));
            Console.WriteLine("Сортировка Шейкером");
            ShakerSort(array);

        }
        
    }
}
