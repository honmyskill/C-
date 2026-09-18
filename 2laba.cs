using System;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int n = 0;

        while (true)
        {
            Console.Write("Введите размерность массива: ");
            string input = Console.ReadLine();
            bool ok = int.TryParse(input, out n);
            if (ok && n > 0) break;
            Console.WriteLine("Размерность должна быть целым, положительным числом, попробуйте еще раз");
        }

        int[] arr = new int[n];
        Console.WriteLine("\nМассив:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = rnd.Next(1, 11);
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        bool[] used = new bool[n];// создание булевых для проверки на каждую итерацию
        int indexi = -1, indexj = -1, kolvo = 0;
        
        /*false означает: «Элемент под этим индексом свободен, у него еще нет пары».
         * true означает: «Элемент уже занят (для него нашли пару), больше его трогать нельзя».*/

        for (int i = 0; i < n - 1; i++)
        {
            if (used[i]) continue;// если true пропускаем.

            for (int j = i + 1; j < n; j++)
            {
                if (!used[j] && arr[i] == arr[j])
                {
                    used[i] = true;//занят 
                    used[j] = true;
                    kolvo++;

                    if (indexi == -1)
                    {
                        indexi = i;// для вывода красным индекс запоминаем
                        indexj = j;
                    }
                    break;
                }
            }
        }
        Console.WriteLine("\nМассив с выделением первой пары:");
        for (int i = 0; i < n; i++)
        {
            if (i == indexi || i == indexj)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(arr[i] + " ");
                Console.ResetColor();
            }
            else
            {
                Console.Write(arr[i] + " ");
            }
        }
        Console.WriteLine();

        Console.WriteLine($"\nКоличество пар равных чисел: {kolvo}");

        if (kolvo == 0)
            Console.WriteLine("Пар равных чисел не найдено.");
    }
}