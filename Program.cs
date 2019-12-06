using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void swap<T>(ref T a, ref T b) { T c = a; a = b; b = c; }

        static void buildHeap(ref double[] arr, int n, ref int count)
        {
            for (int i = n / 2 - 1; i >= 0; i -= 1)
            {
                int k = i;
                double c = arr[i];
                bool isHeap = false;
                while (!isHeap && (2 * k + 1 < n))
                {
                    int j = 2 * k + 1;
                    if (j + 1 < n)
                        if (arr[j] < arr[j + 1])
                            j += 1;
                    if (c >= arr[j])
                        isHeap = true;
                    else
                    {
                        arr[k] = arr[j];
                        k = j;
                    }
                    count += 2;
                }
                arr[k] = c;
            }
        }

        static void Heap(ref double[] arr, int n, ref int count)
        {
            int k = 0;
            double c = arr[0];
            bool isHeap = false;
            while (!isHeap && (2 * k + 1 < n))
            {
                int j = 2 * k + 1;
                if (j + 1 < n)
                    if (arr[j] < arr[j + 1])
                        j += 1;
                if (c >= arr[j])
                    isHeap = true;
                else
                {
                    arr[k] = arr[j];
                    k = j;
                }
                count += 2;
            }
            arr[k] = c;
        }

        static int HeapSort(ref double[] arr)
        {
            int count = 0;
            //Первый этап сортировки
            int n = arr.Length;
            buildHeap(ref arr, n, ref count);

            //Второй этап сортировки
            swap(ref arr[0], ref arr[n - 1]);
            for (int i = n - 1; i >= 2; i -= 1)
            {
                Heap(ref arr, i, ref count);
                swap(ref arr[0], ref arr[i - 1]);
            }
            return count;
        }

        static void Main(string[] args)
        {
            //Генерация входных данных: массив длины n с элементами в диапазоне [a,b]
            Random rand = new Random();
            int n = 10000;
            double a = -100.0;
            double b = 100.0;
            double[] arr = new double[n];

            int count=0;//Счетчик
            var isSorted = true;
            for (int q = 0; q < 5; q += 1)
            {
                for (int i = 0; i < n; i += 1)
                    arr[i] = rand.NextDouble() * (b - a) + a;

                count += HeapSort(ref arr);

                //Проверка на упорядоченность
                for (int i = 0; i < n - 1; i += 1)
                    if (arr[i] > arr[i + 1])
                    {
                        isSorted = false;
                        break;
                    }

                if (!isSorted)
                    break;
            }

            if (isSorted)
                Console.WriteLine("OK");
            else
                Console.WriteLine("Not sorted");

            Console.WriteLine(count/5.0);

            Console.ReadKey();
        }
    }
}
