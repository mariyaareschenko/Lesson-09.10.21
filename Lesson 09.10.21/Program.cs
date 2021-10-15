using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //картинки
using System.IO;

namespace Lesson_09._10._21
{
    public struct Students
    {
        public string name;
        public string surname;
        public int date;
        public string exam;
        public int ball;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Random r = new Random();
            int people_first = r.Next(1, 50);
            int[] first = new int[people_first];
            int people_second = r.Next(1, 50);
            int[] second = new int[people_second];
            int count_five_first = 0;
            int count_five_second = 0;
            for (int i = 0; i < people_first; i++)
            {
                first[i] = r.Next(0, 10);
                if (first[i].Equals(5))
                {
                    count_five_first++;
                }
            }
            for (int i = 0; i < people_second; i++)
            {
                second[i] = r.Next(0, 10);
                if (second[i].Equals(5))
                {
                    count_five_second++;
                }
            }
            if (count_five_first.Equals(count_five_second))
            {
                Console.WriteLine("Drinks All Round! Free Beers on Bjorg!");
            }
            else
            {
                Console.WriteLine("Ой, Бьорг - пончик! Ни для кого пива!");
            }

            Console.WriteLine("Задание 2");
            Dictionary<int, Image> img = new Dictionary<int, Image>();
            for (int i = 1; i < 64; i++)
            {
                if ((i % 32).Equals(0))
                    img.Add(i, Image.FromFile($"{i % 33}.jpg"));
                else
                    img.Add(i, Image.FromFile($"{i % 32}.jpg"));
            }
            img.Add(64, Image.FromFile("32.jpg"));
            foreach (var image in img)
            {
                Console.WriteLine(image.Key + " " + image.Value);
            }
            for (int i = 1; i <= 64; i++)
            {
                var t = img[i];
                int swap = r.Next(1, 64);
                img[i] = img[swap];
                img[swap] = t;
            }

            foreach(var item in img)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.WriteLine("Задание 3");
            Dictionary<int, Students> students = new Dictionary<int, Students>();
            StreamReader reader = new StreamReader("students.txt");
            int people = 0;
            while(reader.ReadLine() != null)
            {
                people++;
            }
            reader = new StreamReader("students.txt");
            for (int i = 1; i < people; i++)
            {
                string str = reader.ReadLine();
                string name = str.Substring(0, str.IndexOf(" "));
                str = str.Remove(0, str.IndexOf(" ") + 1);
                string surname = str.Substring(0, str.IndexOf(" "));
                str = str.Remove(0, str.IndexOf(" ") + 1);
                int date;
                if(!int.TryParse(str.Substring(0, str.IndexOf(" ")),out date))
                {
                    date = 0;
                }
                str = str.Remove(0, str.IndexOf(" ") + 1);
                string exam = str.Substring(0, str.IndexOf(" "));
                str = str.Remove(0, str.IndexOf(" ") + 1);
                int ball;
                if (!int.TryParse(str, out ball))
                {
                    ball = 0;
                }
                Students student = new Students();
                student.name = name;
                student.surname = surname;
                student.date = date;
                student.exam = exam;
                student.ball = ball;
                students.Add(i, student);
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Введите одну из команд: Новый студент; Удалить; Сортировать; Вывести");
                string str = Console.ReadLine();
                if (str.ToLower().Equals("вывести"))
                {
                    foreach(var student in students)
                    {
                        Console.WriteLine($"{student.Key} {student.Value.name} {student.Value.surname} {student.Value.date} {student.Value.exam} {student.Value.ball}");
                    }
                }
                else if(str.ToLower().Equals("новый студент"))
                {
                    Console.WriteLine("Введите имя студента");
                    Students student = new Students();
                    student.name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию студента");
                    student.surname = Console.ReadLine();
                    Console.WriteLine("Введите год рождения студента");
                    while (!int.TryParse(Console.ReadLine(), out student.date))
                    {
                        Console.WriteLine("Введите еще раз");
                    }
                    Console.WriteLine("Введите экзамен студента");
                    student.exam = Console.ReadLine();
                    Console.WriteLine("Введите балл студента");
                    while (!int.TryParse(Console.ReadLine(), out student.ball))
                    {
                        Console.WriteLine("Введите еще раз");
                    }
                    students.Add(students.Count + 1, student);
                }
                else if (str.ToLower().Equals("удалить"))
                {
                    Console.WriteLine("Введите имя студента");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию студента");
                    string surname = Console.ReadLine();
                    for(int i = 1; i <= students.Count; i++)
                    {
                        if(students[i].name.Equals(name) && students[i].surname.Equals(surname))
                        {
                            var t = students[i];
                            students[i] = students[students.Count];
                            students[students.Count] = t;
                            students.Remove(students.Count);
                        }
                    }
                }
                else if (str.ToLower().Equals("сортировать"))
                {
                    for(int i = 1; i <= students.Count; i++)
                    {
                        for(int j = 1; j <= students.Count; j++)
                        {
                            if(students[j].ball > students[j + 1].ball)
                            {
                                var t = students[j];
                                students[j] = students[j + 1];
                                students[j + 1] = t;
                            }
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
