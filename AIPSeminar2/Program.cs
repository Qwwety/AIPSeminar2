using System;
using System.Collections.Generic;
using System.Linq;

namespace AIPSeminar2
{
    class Program
    {
        static int[] StandardArray;
        static int[,] StandardDoubleArray;



        static void Main(string[] args)
        {
            /*Задание с одномерными масивами,чтобы все работало раскоменьтите первую строку после этой и нужные вам задания, у них всех есть коменты1*/
            //StandardArray = CreateStandardArray();
            //Task1();
            //Task7();
            //Task8();
            //Task10();

            /*Задания с двумерными масивами, чтобы все работало раскоменьтите первую строку после этой и нужные вам задания, у них всех есть коменты*/
            //StandardDoubleArray = CreateStandardDoubleArray();
            //Task1_1();
            //Task2_2();
            //Task3_3();
            //Task4_4();
            //Task5_5();
            //Console.WriteLine(Task6_6());


        }

        private static int[,] CreateStandardDoubleArray()
        {
            int ArrayLength = 0;
            int InnerArrayLength = 0;
            int NextElement = 0;

            Console.WriteLine("Dlina");
            ArrayLength = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Dlina pod Masiva");
            InnerArrayLength = Convert.ToInt32(Console.ReadLine());
            int[,] LocalArray = new int[ArrayLength, InnerArrayLength];

            for (int i = 0; i < ArrayLength; i++)
            {
                Console.WriteLine("Next pod Masiv");
                for (int j = 0; j < InnerArrayLength; j++)
                {
                    Console.WriteLine("Next Element");
                    NextElement = Convert.ToInt32(Console.ReadLine());
                    LocalArray[i, j] = NextElement;
                }

            }

            Console.WriteLine("_____");
            return LocalArray;
        }

        static int[] CreateStandardArray()
        {
            int ArrayLength = 0;
            int NextElement = 0;

            Console.WriteLine("Dlina");
            ArrayLength = Convert.ToInt32(Console.ReadLine());
            int[] LocalArray = new int[ArrayLength];


            for (int i = 0; i < ArrayLength; i++)
            {
                Console.WriteLine("Next Element");
                NextElement = Convert.ToInt32(Console.ReadLine());

                LocalArray[i] = NextElement;
            }

            Console.WriteLine("_____");
            return LocalArray;
        }


        /// <summary>
        ///1.   Составить и вывести на экран новый массив с номерами элементов исходного массива, которые равны заданному значению. Заданное значение вводится с клавиатуры.
        /// </summary>
        /// <returns></returns>
        static int[] FillArray()
        {
            int[] ChangeableArray = new int[StandardArray.Length];

            int NextElemet = 0;
            int ElementNumber = 0;



            while (ElementNumber < StandardArray.Length)
            {
                try
                {
                    NextElemet = Convert.ToInt32(Console.ReadLine());

                    if (NextElemet == 777)
                    {
                        break;
                    }

                    ChangeableArray[ElementNumber] = NextElemet;
                    ElementNumber++;
                }
                catch { }
            }

            return ChangeableArray;
        }
        /// <summary>
        /// 1.  Составить и вывести на экран новый массив с номерами элементов исходного массива, которые равны заданному значению. Заданное значение вводится с клавиатуры.
        /// </summary>
        static void Task1()
        {
            int[] LoacalArray = FillArray();

            foreach (int Elemt in LoacalArray)
            {
                Console.WriteLine(StandardArray[Elemt]);
            }
        }


        /// <summary>
        /// 7.	Переписать элементы массива в обратном порядке на том же месте. Вывести измененный массив на экран. Я не совсем понял, что значит "на том же месте"
        /// </summary>
        static void Task7()
        {
            int[] LoacalArray = StandardArray.Reverse().ToArray();

            foreach (int Element in LoacalArray)
            {
                Console.WriteLine(Element);
            }
        }

        /// <summary>
        /// 8.	Составить и вывести на экран массив из различных (по значению) элементов исходного массива.
        /// </summary>
        static void Task8()
        {
            int[] LocalArray = new int[StandardArray.Length];
            Random random = new Random();

            int RandomElement;
            for (int i = 0; i < LocalArray.Length; i++)
            {
                RandomElement = StandardArray.ElementAt(random.Next(0, StandardArray.Length));
                LocalArray[i] = RandomElement;
            }

            foreach (int Element in LocalArray)
            {
                Console.WriteLine(Element);
            }

        }

        /// <summary>
        /// 10.	Составить и вывести на экран два массива: массив повторяющихся элементов исходного массива и массив их частот. Сделала, через словарику по 2-м присчинам хотел вспомнить Linq и не придкмал ка их можно кросиво сопоставить
        /// </summary>
        static void Task10()
        {
            int[] Repeatable;
            Dictionary<int, int> RepeatableCount = new Dictionary<int, int>();

            Repeatable = StandardArray.GroupBy(x => x)
                             .Where(g => g.Count() > 1)
                             .Select(y => y.Key)
                             .ToArray();

            RepeatableCount = StandardArray.GroupBy(x => x)
                            .Where(y => y.Count() > 1)
                            .ToDictionary(g => g.Key, h => h.Count());


            foreach (int Element in Repeatable)
            {
                Console.WriteLine(Element);
            }


            foreach (KeyValuePair<int, int> Local in RepeatableCount)
            {
                Console.WriteLine($"Elemetn::{Local.Key}, Repeat Count::{Local.Value}");
            }

        }


        static int[] ConvertToSingelArray(int InnerArrayNumber)
        {
            int[] Local = new int[StandardDoubleArray.GetLength(1)];

            for (int i = 0; i < StandardDoubleArray.GetLength(1); i++)
            {
                Local[i] = StandardDoubleArray[InnerArrayNumber, i];
            }

            return Local;
        }


        /// <summary>
        /// 1.	число неотрицательных элементов в i-ой строке.
        /// </summary>
        static void Task1_1()
        {

            int InnerArrayNumber = 0;

            Console.WriteLine("Nomer  Pod Masiva");
            InnerArrayNumber = Convert.ToInt32(Console.ReadLine());

            int[] local = ConvertToSingelArray(InnerArrayNumber);

            int Count = 0;

            Count = local.GroupBy(x => x)
                       .Where(y => y.Key > 0)
                       .Select(h => h.Sum()).Sum();

            Console.WriteLine(Count);

        }

        /// <summary>
        /// 2.	среднее арифметическое положительных элементов в i-ом столбце. .
        /// </summary>
        static void Task2_2()
        {
            int InnerArrayNumber = 0;

            Console.WriteLine("Nomer  Pod Masiva");
            InnerArrayNumber = Convert.ToInt32(Console.ReadLine());

            int[] local = ConvertToSingelArray(InnerArrayNumber);

            double Count = 0;

            Count = local.GroupBy(x => x)
                       .Where(y => y.Key > 0)
                       .Select(h => h.Average()).Average();

            Console.WriteLine(Count);
        }

        /// <summary>
        /// 3.	минимальное значение в i-ой строке.
        /// </summary>
        static void Task3_3()
        {
            int InnerArrayNumber = 0;

            Console.WriteLine("Nomer  Pod Masiva");
            InnerArrayNumber = Convert.ToInt32(Console.ReadLine());

            int[] local = ConvertToSingelArray(InnerArrayNumber);

            double Count = 0;

            Count = local.GroupBy(x => x)
                       .Select(h => h.Min()).Min();

            Console.WriteLine(Count);
        }

        /// <summary>
        /// 4.	количество простых чисел в i-ой строке.
        /// </summary>
        static void Task4_4()
        {
            int InnerArrayNumber = 0;

            Console.WriteLine("Nomer  Pod Masiva");
            InnerArrayNumber = Convert.ToInt32(Console.ReadLine());

            int[] local = ConvertToSingelArray(InnerArrayNumber);

            int Result = 0;

            foreach (int Num in local)
            {

                if (IsSimple(Num)==true)
                {
                    Result++;
                }
            }


            Console.WriteLine(Result);
        }

        static bool IsSimple(int Num)
        {
            var result = true;

            if (Num > 1)
            {
                for (var i = 2u; i < Num; i++)
                {
                    if (Num % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 5.	число элементов i-ой строки, значения которых меньше заданного значения.
        /// </summary>
        static void Task5_5()
        {
            int InnerArrayNumber = 0;
            int LessWhenNum = 0;

            Console.WriteLine("Nomer Pod Masiva");
            InnerArrayNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Zadanoe Chislo");
            LessWhenNum = Convert.ToInt32(Console.ReadLine());

            int[] local = ConvertToSingelArray(InnerArrayNumber);


            double Count = 0;

            Count = local.GroupBy(x => x).Where(y => y.Key < LessWhenNum).Count();

            Console.WriteLine(Count);
        }

        /// <summary>
        /// 6.	равно true, если значения элементов i-ой строки упорядочены по возрастанию, и False в противном случае.
        /// </summary> 
        static bool Task6_6()
        {
            int InnerArrayNumber = 0;

            Console.WriteLine("Nomer Pod Masiva");
            InnerArrayNumber = Convert.ToInt32(Console.ReadLine());

            int[] local = ConvertToSingelArray(InnerArrayNumber);

            for (int i = local.Length - 2; i > 0; i--)
            {
                if (local[i + 1] < local[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
