using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyMethods;

namespace HW5
{
    //    Задача ЕГЭ.
    //На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
    //школы.В первой строке сообщается количество учеников N, которое не меньше 10, но не
    //превосходит 100, каждая из следующих N строк имеет следующий формат:
    //<Фамилия> <Имя> <оценки>,
    //где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
    //более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
    //пятибалльной системе. <Фамилия> и<Имя>, а также <Имя> и<оценки> разделены одним пробелом.
    //Пример входной строки:
    //Иванов Петр 4 5 3
    //Требуется написать как можно более эффективную программу, которая будет выводить на экран
    //фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
    //набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

    struct Info
    {
        public string student;
        public int grade1;  //Как инициализировать массив grades[] внутри структуры чтобы использовать массив [3] вместо 3х полей
        public int grade2;  //с оценками? При заполнении info[] из файла ругается Ссылка на объект не указывает на экземпляр объекта
        public int grade3;
        public double Average
        {
            get
            {
                double sum = 0;
                    sum = grade1 + grade2 + grade3;
                return sum / 3;
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            string fname = "C:\\GB\\info.txt";
            int n;
            Info[] info;
            List<string> worse = new List<string>();


            My.TypeLine("Добро пожаловать в программу по подсчету результатов экзаменов учениками!\n");
            Thread.Sleep(60);
            My.TypeLine($"Поиск файла по пути {fname}...");
            My.LoadScreen(2000);
            if (!File.Exists(fname))
            {
                My.TypeLine("Ошибка! Файл не найден!\n");
                Thread.Sleep(60);
                My.TypeLineQuick("Создайте txt файл В КОДИРОВКЕ UNICODE со следующими входными данными:\n" +
                    "\t-В первой строке количество учеников, не меньше 10, но не более 100\n" +
                    "\t-Далее строки формата <Фамилия> <Имя> <оценки>, где <Фамилия> не более чем 20 символов,\n" +
                    "\t<Имя> не более 15 символов, <оценки> — через пробел три целых числа по 5 бальной системе.\n" +
                    "\t-<Фамилия> <Имя> <оценки> разделены пробелом. Пример входной строки:\n" +
                    "Иванов Петр 4 5 3");
                My.PauseMsg();
                do
                {
                    My.TypeLine("Пытаемся считать файл...");
                    My.LoadScreen(2000);
                    if (!File.Exists(fname))
                    {
                        My.TypeLineQuick("Ошибка! Файл не найден! Создайте файл!");
                        My.PauseMsg();
                    }
                } while (!File.Exists(fname));
            }
            My.TypeLine("Файл успешно загружен!\n");
            My.PauseMsg();
            try
            {
                StreamReader sr = new StreamReader(fname);
                if (int.TryParse(sr.ReadLine(), out n))
                {
                    if (n < 10 || n > 100)
                    {
                        ManualNumber(out n, out info);
                    }
                    else info = new Info[n];

                }
                else ManualNumber(out n, out info);

                for (int i = 0; i < n; i++)
                {
                    string[] sa = sr.ReadLine().Split(' ');
                    if (sa[0].Length > 20)
                    {
                        sa[0] = sa[0].Remove(19);
                    }
                    if (sa[1].Length > 15)
                    {
                        sa[1] = sa[1].Remove(14);
                    }
                    info[i].student = $"{sa[0]} {sa[1]}";

                    info[i].grade1 = int.Parse(sa[2]);
                    info[i].grade2 = int.Parse(sa[3]);
                    info[i].grade3 = int.Parse(sa[4]);
                }
                sr.Close();

                Sort(info);

                My.TypeLine("Худшие 3 или более учеников по среднему баллу:\n");
                Console.WriteLine();
                Worse(ref info, ref worse);
                PrintWorse(ref worse);
                Console.WriteLine();
                My.Exit();
            }
            catch (Exception e)
            {
                My.TypeLineQuick($"Ой! Ошибка:\n" +
                    $"{e.Message}\n");
                My.Exit();
            }

        }

        public static void Sort(Info[] info) //Сортируем пузырьком чтобы выделить 3х худших
        {
            for (int i = 0; i < info.Length; i++)
                for (int j = 0; j < info.Length - 1; j++)
                    if (info[j].Average > info[j + 1].Average)
                    {
                        Info t = info[j];
                        info[j] = info[j + 1];
                        info[j + 1] = t;
                    }
        }

        public static void ManualNumber(out int n, out Info[] info)
        {
            My.TypeLine("Ошибка! Выход за пределы диапозона > 10 и < 100!\n" +
                        "Введите вручную колличество учеников: ");
            n = My.ForceReadInteger(10, 100);
            info = new Info[n];
        }

        public static void Worse (ref Info[] info, ref List<string> worse) //Выделяем 3х худших
        {
            for (int i = 0; i < 3; i++)
            {
                worse.Add($"{info[i].student}, средняя оценка: {info[i].Average}");
            }
            for (int i = 3; i < info.Length; i++)
            {
                if (info[i].Average <= info[2].Average)
                {
                    worse.Add($"{info[i].student}, средняя оценка: {info[i].Average}");
                }
            }
        }

        public static void PrintWorse(ref List<string> worse)
        {
            foreach (String s in worse)
            {
                My.TypeLine($"{s}\n");
            }
        }

    }
}
