using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMethods;
using _2DimenArray;
using System.IO;

namespace HW4
{
    //5 *а) Реализовать библиотеку с классом для работы с двумерным массивом.
    //Реализовать конструктор, заполняющий массив случайными числами.Создать методы, которые возвращают сумму всех элементов массива,
    //сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство,
    //возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива(через параметры, 
    //используя модификатор ref или out).
    //** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    // ** в) Обработать возможные исключительные ситуации при работе с файлами.
    //  Романенко Андрей Григорьевич

    class Program
    {
        static void Main(string[] args)
        {
            string maxNum, fname = "C:\\array.txt";
            bool flag = false;
            My.TypeLine($"Пытаемся считать файл в массив по адрессу C:\\array.txt\n");
            My.PauseMsg();
            TwoDimenArray array = new TwoDimenArray(fname, out flag);
            if (flag)
            {
                My.TypeLine("Считывание из файла в массив а...");
                My.LoadScreen(2000);
                My.TypeLine("\n" + array.ToString());
                My.TypeLine($"Сумма всех элементов массива a больше 12: {array.Sum(12)}\n");
                My.TypeLine($"Сумма всех элементов массива а: {array.Sum()}\n");
                My.TypeLine($"Номер максимального элемента массива а: {array.MaxNum(out maxNum)}\n");
                My.Exit();
            }
            else
            {
                My.TypeLine("\nВведите размернсть массива: ");
                int n = My.ForceReadInteger();
                My.TypeLine("Введите диапозон чисел для случайной генерации массива:\n" +
                    "от ");
                int from = My.ForceReadInteger();
                My.TypeLine("до ");
                int to = My.ForceReadInteger();
                TwoDimenArray array2 = new TwoDimenArray(n, from, to);
                int max = array2.Max;
                My.TypeLine($"Массив а:\n");
                Console.WriteLine(array2.ToString());
                My.TypeLine($"Сумма всех элементов массива a больше 12: {array2.Sum(12)}\n");
                My.TypeLine($"Сумма всех элементов массива а: {array2.Sum()}\n");
                My.TypeLine($"Номер максимального элемента массива а: {array2.MaxNum(out maxNum)}\n");
                My.TypeLine("Запись массива в файл С:\\array.txt...");
                My.LoadScreen(2000);
                array2.Write2File(fname, out flag);
                if (flag)
                {
                    My.TypeLine("Запись успешно завершена!\n");
                    My.Exit();
                }
            }
        }
    }
}
