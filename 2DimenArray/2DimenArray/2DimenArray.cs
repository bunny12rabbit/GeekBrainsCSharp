using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMethods;

namespace _2DimenArray
{
    //5 *а) Реализовать библиотеку с классом для работы с двумерным массивом.
    //Реализовать конструктор, заполняющий массив случайными числами.Создать методы, которые возвращают сумму всех элементов массива,
    //сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство,
    //возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива(через параметры, 
    //используя модификатор ref или out).
    //** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    // ** в) Обработать возможные исключительные ситуации при работе с файлами.
    //  Романенко Андрей Григорьевич

    public class TwoDimenArray
    {
        int[,] a;
        int min, max;

        public TwoDimenArray(int n, int min, int max)
        {
            a = new int[n, n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rnd.Next(min, max);
        }

        public TwoDimenArray(string fname, out bool flag)
        {
            flag = false;
            try
            {
                StreamReader sr = new StreamReader(fname);
                string[] lines = File.ReadAllLines(fname);
                a = new int[lines.Length, lines[0].Split(' ').Length-1];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] temp = lines[i].Split(' ');
                    for (int j = 0; j < temp.Length-1; j++)
                        a[i, j] = Convert.ToInt32(temp[j]);
                }
                flag = true;
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                My.TypeLineQuick("\nОшибка чтения файла, возможно указанный файл отсутствует!");
                My.TypeLineQuick($"\n{e.Message}");
                My.PauseMsg();
                Console.Clear();
                //Environment.Exit(0);
                
            }
            
        }

        public TwoDimenArray(string fname)
        {
            try
            {
                StreamReader sr = new StreamReader(fname);
                string[] lines = File.ReadAllLines(fname);
                a = new int[lines.Length, lines[0].Split(' ').Length - 1];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] temp = lines[i].Split(' ');
                    for (int j = 0; j < temp.Length - 1; j++)
                        a[i, j] = Convert.ToInt32(temp[j]);
                }
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                My.TypeLineQuick("\nОшибка чтения файла, возможно указанный файл отсутствует!");
                My.TypeLineQuick($"\n{e.Message}");
                My.PauseMsg();
                Console.Clear();
                //Environment.Exit(0);

            }

        }

        public int Min
        {
            get
            {
                min = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] < min) min = a[i, j];
                return min;
            }
        }

        public int Max
        {
            get
            {
                max = a[0, 0];
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        if (a[i, j] > max) max = a[i, j];
                return max;
            }
        }

        public double Sum()
        {
            double sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    sum += a[i, j];
            return sum;
        }

        public int Sum(int from)
        {
            int sum = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > from)
                        sum += a[i, j];
                }
            return sum;
        }

        public double Average
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                    for (int j = 0; j < a.GetLength(1); j++)
                        sum += a[i, j];
                return sum / a.GetLength(0) / a.GetLength(1);
            }

        }


        public void Write2File(string fname, out bool flag)
        {
            flag = false;
            try
            {
                StreamWriter sw = new StreamWriter(fname);
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        sw.Write(a[i, j] + " ");
                    }
                    if (i<a.GetLength(0)-1)
                    sw.WriteLine();
                }
                sw.Close();
                flag = true;
            }
            catch (Exception e)
            {
                My.TypeLine("Ошибка записи!\n" +
                    " Возможно программа не было запущена с ПРАВАМИ АДМИНИСТРАТОРА...\n");
                My.TypeLineQuick($"{e.Message}\n");
                My.Exit();
                Console.Clear();
            }

        }

        public string MaxNum(out string numMax)
        {
            numMax = "";
            int max = a[0,0];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] > max)
                    {
                        max = a[i, j];
                        numMax = $"{i.ToString()},  {j.ToString()}";
                    }
            return numMax;
        }

        public override string ToString ()
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    s += $"{a[i, j]}\t";
            s += "\n";
            }
            return s;
        }


    }
}
