using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework
{
    class Program
    {
        static bool PasswordVerification(string[] array, ref string pass_bin)
        {
            for (int i = 0; i < array.Length; i++)
            {
                string temp = "";
                for (int j = 0; j < array[i].Length; j++)
                {
                    temp += Convert.ToString(array[i][j], 2);
                }
                if (temp.Equals(pass_bin))
                {
                    pass_bin = array[i];
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Проверка пароля");
            string[] password_list = new string[3];
            StreamReader reader = new StreamReader("password.txt");
            string pass_bin = reader.ReadToEnd();
            pass_bin = pass_bin.Replace(" ", "");
            reader.Close();
            for (int i = 0; i < password_list.Length; i++)
            {
                Console.WriteLine("Введите возможные пароли: ");
                password_list[i] = Console.ReadLine();
            }
            if(PasswordVerification(password_list,ref pass_bin))
            {
                Console.WriteLine("Верный пароль: {0}", pass_bin);
            }
            else
            {
                Console.WriteLine("false");
            }

            Console.WriteLine("Адская кухня");
            Console.WriteLine("Что кричит Гордон Рамзи?");
            string phrase = Console.ReadLine();
            string vowels = "АЕЁИОУЫЭЮЯAEIOU";
            if (phrase.Split().Length.Equals(4))
            {
                //string new_phrase = phrase;
                string new_phrase = phrase.Replace(" ", "!!!! ").Replace("a", "@").Replace("A", "@").ToUpper();
                for (int i = 0; i < new_phrase.Length; i++)
                {
                    if (vowels.Contains(new_phrase[i]))
                    {
                        new_phrase = new_phrase.Replace(new_phrase[i], '*');
                    }  
                }
                Console.WriteLine(new_phrase + "!!!!");
            }
            else
            {
                Console.WriteLine("Гордoн Рамзи не кричит");
            }
            Console.ReadKey();
        }
    }
}
