using System;


namespace OPD11
{
    public delegate int GetProperty(int[] arr);

    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = { new[] { 1, 2, 3 },
                            new[] { 0, 0, 0, 0, 0 },
                            new[] { 2, 3},
                            new[] { 10, 20, 30},
                            new[] { 9, 1000}};

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выбирите тип сортировки");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1 – По сумме элементов");
                Console.WriteLine("2 – По максимальному элементу");
                Console.WriteLine("3 – По минимальному элементу\n");
                Console.WriteLine("0 - Выход из программы\n");

                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Выбирите направление сортировки");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("1 – По возрастанию");
                        Console.WriteLine("2 – По убыванию");
                        switch (char.ToLower(Console.ReadKey(true).KeyChar))
                        {
                            case '1':
                                Console.Clear();
                                Console.WriteLine("По сумме + возрастание\n");
                                new Bubble(arr, PropertyOption.getSum).sort(true);
                                show(arr);
                                break;
                            case '2':
                                Console.Clear();
                                Console.WriteLine("По сумме + убывание\n");
                                new Bubble(arr, PropertyOption.getSum).sort(false);
                                show(arr);
                                break;
                            default:
                                Console.WriteLine("Такого выбора нет!");
                                break;
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Выбирите направление сортировки");
                        Console.WriteLine("\t1 – По возрастанию");
                        Console.WriteLine("\t2 – По убыванию");
                        switch (char.ToLower(Console.ReadKey(true).KeyChar))
                        {
                            case '1':
                                Console.Clear();
                                Console.WriteLine("По максимальному + возрастание\n");
                                new Bubble(arr, PropertyOption.getMax).sort(true);
                                show(arr);
                                break;
                            case '2':
                                Console.Clear();
                                Console.WriteLine("По максимальному + убывание\n");
                                new Bubble(arr, PropertyOption.getMax).sort(false);
                                show(arr);
                                break;
                            default:
                                Console.WriteLine("Такого выбора нет!");
                                break;
                        }
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Выбирите направление сортировки");
                        Console.WriteLine("\t1 – По возрастанию");
                        Console.WriteLine("\t2 – По убыванию");
                        switch (char.ToLower(Console.ReadKey(true).KeyChar))
                        {
                            case '1':
                                Console.Clear();
                                Console.WriteLine("По минимальному + возрастание\n");
                                new Bubble(arr, PropertyOption.getMin).sort(true);
                                show(arr);
                                break;
                            case '2':
                                Console.Clear();
                                Console.WriteLine("По минимальному + убывание\n");
                                new Bubble(arr, PropertyOption.getMin).sort(false);
                                show(arr);
                                break;
                            default:
                                Console.WriteLine("Такого выбора нет!");
                                break;
                        }
                        break;

                    case '0': return;
                    default: Console.WriteLine("Такой функции нет!"); break;
                }
                Console.ReadKey();
            }

        }

        private static void show(int[][] arr)
        {
            foreach (var a in arr)
            {
                foreach (var b in a)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    public static class PropertyOption {
        public static int getSum(int[] arr)
        {
            int sum = 0;
            foreach (var a in arr)
            {
                sum += a;
            }
            return sum;
        }

        public static int getMax(int[] arr)
        {
            int max = 0;
            foreach (var a in arr)
            {
                if (a > max)
                    max = a;
            }
            return max;
        }

        public static int getMin(int[] arr)
        {
            int min = int.MaxValue;
            foreach (var a in arr)
            {
                if (a < min)
                    min = a;
            }
            return min;
        }
    }

    public class Bubble
    {
        public int[][] arr;
        public GetProperty property;

        public Bubble(int[][] arr, GetProperty property)
        {
            this.arr = arr;
            this.property = property;
        }

        public void sort(bool asc)
        {
            int[] temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if ((property(arr[i]) > property(arr[j]) && asc) || property(arr[i]) < property(arr[j]) && !asc)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
