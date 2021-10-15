using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_5
{
    class Program
    {
        static void Output(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j]);
                }
            }
            Console.WriteLine();
        }
        static int[,] Multiplication(int[,] a, int[,] b)
        {
            int[,] result = new int[2, 2];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
        static double[] AverageTemperature(double[,] array)
        {
            double[] result = new double[12];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    sum += array[i, j];
                    result[i] = sum / array.GetLength(1);
                }
            }
            return result;
        }
        static double[] TemperatureValue(Dictionary<string, double[]> array)
        {
            string[] mounth = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            double[] result = new double[array.Keys.Count];
            for (int i = 0; i < array.Keys.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < array.Values.Count; j++)
                {
                    sum += array[mounth[i]][j];
                }
                result[i] = sum / array.Keys.Count;
            }
            return result;
        }
        static void LetterDefinition(char[] array)
        {
            int vowels = 0, consonants = 0;
            foreach(char i in array)
            {
                if (Char.IsLetter(i))
                {
                    if("AEIOUaeiouАЕЁИОУЫЭЮЯаеёиоуыэюя".IndexOf(i)!= -1)
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
            }
            Console.WriteLine("Общее количесвто символов: {0}", array.Length);
            Console.WriteLine("Количесвто гласных букв: {0}", vowels);
            Console.WriteLine("Количество согласных букв: {0}", consonants);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 6.1");
            StreamReader text = new StreamReader("file.txt");
            char[] contents = text.ReadToEnd().ToCharArray();
            text.Close();
            LetterDefinition(contents);

            Console.WriteLine("Упражнение 6.2");
            int[,] mat1 = new int[2, 2];
            int[,] mat2 = new int[2, 2];
            for(int i = 0; i < mat1.GetLength(0); i++)
            {
                for(int j = 0; j < mat1.GetLength(1); j++)
                {
                    Console.WriteLine("Введите элемент 1-ой матрицы [{0}, {1}]", i, j);
                    mat1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();
            for (int i = 0; i < mat2.GetLength(0); i++)
            {
                for (int j = 0; j < mat2.GetLength(1); j++)
                {
                    Console.WriteLine("Введите элемент 2-ой матрицы [{0}, {1}]", i, j);
                    mat2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Матрица №1: ");
            Output(mat1);
            Console.WriteLine("Матрица №2: ");
            Output(mat2);
            Console.Write("Произведение 1-ой и 2-ой матрицы = ");
            int[,] result = Multiplication(mat1, mat2);
            Output(result);

            Console.WriteLine("Упражнение 6.3");
            Random r = new Random();
            int max_temp = 30;
            int min_temp = -30;
            double[,] temperature = new double[12, 30];
            for(int i = 0; i < temperature.GetLength(0); i++)
            {
                for(int j = 0; j < temperature.GetLength(1); j++)
                {
                    temperature[i, j] = r.NextDouble()*(max_temp-min_temp) + min_temp;
                }
            }
            double[] sr_znach = AverageTemperature(temperature);
            Array.Sort(sr_znach);
            Console.WriteLine("Средние значения температуры: ");
            for (int i = 0; i < sr_znach.Length; i++)
            {
                Console.WriteLine(sr_znach[i]);
            }

            Console.WriteLine("Домашнее задание 6.1");
            text = new StreamReader("file.txt");
            List<char> letters = new List<char>();
            letters = text.ReadToEnd().ToList<char>();
            text.Close();
            int vowels = 0, consonants = 0;
            foreach(char simbol in letters)
            {
                if (Char.IsLetter(simbol))
                {
                    if ("AEIOUaeiouАЕЁИОУЫЭЮЯаеёиоуыэюя".IndexOf(simbol) != -1)
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
            }
            Console.WriteLine("Общее количесвто символов: {0}", letters.Count);
            Console.WriteLine("Количесвто гласных букв: {0}", vowels);
            Console.WriteLine("Количество согласных букв: {0}", consonants);


            Console.WriteLine("Домашнее задание 6.3");
            Dictionary<string, double[]> temperature_1 = new Dictionary<string, double[]>();
            int count = 12;
            for (int i = 0; i < count; i++)
            {
                double[] temp_day = new double[30];
                for (int j = 0; j < temp_day.Length; j++)
                {
                    temp_day[j] = r.NextDouble() * (max_temp - min_temp) + min_temp;
                }
                switch (i)
                {
                    case 1:
                        temperature_1.Add("Январь", temp_day);
                        break;
                    case 2:
                        temperature_1.Add("Февраль", temp_day);
                        break;
                    case 3:
                        temperature_1.Add("Март", temp_day);
                        break;
                    case 4:
                        temperature_1.Add("Апрель", temp_day);
                        break;
                    case 5:
                        temperature_1.Add("Май", temp_day);
                        break;
                    case 6:
                        temperature_1.Add("Июнь", temp_day);
                        break;
                    case 7:
                        temperature_1.Add("Июль", temp_day);
                        break;
                    case 8:
                        temperature_1.Add("Август", temp_day);
                        break;
                    case 9:
                        temperature_1.Add("Сентябрь", temp_day);
                        break;
                    case 10:
                        temperature_1.Add("Октябрь", temp_day);
                        break;
                    case 11:
                        temperature_1.Add("Ноябрь", temp_day);
                        break;
                    case 12:
                        temperature_1.Add("Декабрь", temp_day);
                        break;
                }
            }
            double[] sr_znach_1 = TemperatureValue(temperature_1);
            Array.Sort(sr_znach_1);
            Console.WriteLine("Средние значения температуры: ");
            for (int i = 0; i < sr_znach_1.Length; i++)
            {
                Console.WriteLine(sr_znach_1[i]);
            }
            Console.ReadKey();
        }
    }
}
