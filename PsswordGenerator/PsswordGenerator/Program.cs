namespace PsswordGenerator
{
    internal class Program
    {
        static char[] Spezs =
            {
                '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
                '-', '_', '=', '+', '[', ']', '{', '}', ';', ':',
                ',', '.', '<', '>', '/', '?', '\\', '|', '`', '~',
                '"', '\''
            };

        static void Main(string[] args)
        {
            int length;
            int minCountSpez;
            int minCountNumbers;
            int minCountHigh;
            int minCountLow;

            while (true)
            {
                Console.WriteLine("Введите построчно Длину, минимальные количества СпецСимволов, Чисел, Букв верхнего регистра, Букв нижнего регистра:");

                length = Convert.ToInt32(Console.ReadLine());
                minCountSpez = Convert.ToInt32(Console.ReadLine());
                minCountNumbers = Convert.ToInt32(Console.ReadLine());
                minCountHigh = Convert.ToInt32(Console.ReadLine());
                minCountLow = Convert.ToInt32(Console.ReadLine());

                if (length >= minCountHigh + minCountSpez + minCountNumbers + minCountLow)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы требуете ввести больше символов, чем позволяет длина!");
                }
            }

            int countSpezs;
            int countNumbers;
            int countHigh;
            int countLow;

            countSpezs = Random.Shared.Next(minCountSpez, length + 1 - (minCountNumbers + minCountHigh + minCountLow));
            countNumbers = Random.Shared.Next(minCountNumbers, length + 1 - (countSpezs + minCountHigh + minCountLow));
            countHigh = Random.Shared.Next(minCountHigh, length + 1 - (countSpezs + countNumbers + minCountLow));
            countLow = length - (countHigh + countSpezs + countNumbers);

            int[] arr_Spez = new int[countSpezs];
            int[] arr_Numbers = new int[countNumbers];
            int[] arr_Highs = new int[countHigh];
            int[] arr_Lows = new int[countLow];

            for (int i = 0; i < arr_Spez.Length; i++)
            {
                arr_Spez[i] = Spezs[Random.Shared.Next(0, Spezs.Length)];
            }

            for (int i = 0; i < arr_Numbers.Length; i++)
            {
                arr_Numbers[i] = '0' + Random.Shared.Next(0, 10);
            }

            for (int i = 0; i < arr_Highs.Length; i++)
            {
                arr_Highs[i] = Convert.ToChar(Random.Shared.Next(65, 91));
            }

            for (int i = 0; i < arr_Lows.Length; i++)
            {
                arr_Lows[i] = Convert.ToChar(Random.Shared.Next(97, 123));
            }

            int[] spezs_Indexes = new int[countSpezs];
            int[] numbers_Indexes = new int[countNumbers];
            int[] high_Indexes = new int[countHigh];
            int[] lows_Indexes = new int[countLow];

            List<int> allesFreiIndexes = new List<int>();

            for (int i = 0; i < length; i++)
            {
                allesFreiIndexes.Add(i);
            }
            
            SetIndexes(spezs_Indexes, allesFreiIndexes);
            SetIndexes(numbers_Indexes, allesFreiIndexes);
            SetIndexes(high_Indexes, allesFreiIndexes);
            SetIndexes(lows_Indexes, allesFreiIndexes);

            char[] result = new char[length];
            ImplementResult(countSpezs, arr_Spez, spezs_Indexes, result);
            ImplementResult(countNumbers, arr_Numbers, numbers_Indexes, result);
            ImplementResult(countHigh, arr_Highs, high_Indexes, result);
            ImplementResult(countLow, arr_Lows, lows_Indexes, result);

            Console.WriteLine(result);
        }

        private static void ImplementResult(int count, int[] arr, int[] arr_Indexes, char[] result)
        {
            for (int i = 0; i < count; i++)
            {
                result[arr_Indexes[i]] = Convert.ToChar(arr[i]);
            }
        }

        private static void SetIndexes(int[] array, List<int> listIndexes)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int temp = Random.Shared.Next(0, listIndexes.Count);
                array[i] = listIndexes[temp];
                listIndexes.RemoveAt(temp);
            }
        }
    }
}
