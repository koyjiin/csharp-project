using System;

namespace экзПМ._06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Количество элеметнов в массиве: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[num];
            Random Rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Rnd.Next(-10, 10);
                Console.Write(arr[i] + " ");
            }
            int temp = 0;
            for (int i = 0; i < num; i++)
            {
                if (arr[i] > 0)
                {
                    temp = arr[i];
                }
            }
            for (int i = 0; i < num; i++)
            {
                if (arr[i] > 0)
                {
                    if (arr[i] < temp)
                    {
                        temp = arr[i];
                    }
                }
            }
            if (temp == 0)
            {
                Console.Write("Нет положительных элементов");
            }
            else
            {
                Console.Write(" " + "Минимальный положительный элемент " + temp);
            }
            Console.ReadLine();

        }
    }
}
