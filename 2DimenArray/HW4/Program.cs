using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMethods;
using _2DimenArray;

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
            string maxNum;
            My.TypeLine($"Создайте файл с двумерным массивом, отделяя числа пробелом по адрессу C:\\input.txt\n");
            My.PauseMsg();
            TwoDimenArray array2 = new TwoDimenArray("D:\\input.txt");
            My.TypeLine("Считывание из файла в массив а...");
            My.LoadScreen(2000);
            My.TypeLine("\n" + array2.ToString());
            My.PauseMsg();

            My.TypeLine("Введите размернсть массива: ");
            int n = My.ForceReadInteger();
            My.TypeLine("Введите диапозон чисел для случайной генерации массива:\n" +
                "от ");
            int from = My.ForceReadInteger();
            My.TypeLine("до ");
            int to = My.ForceReadInteger();
            TwoDimenArray array = new TwoDimenArray(n, from, to);
            int max = array.Max;
            My.TypeLine($"Массив а:\n");
            Console.WriteLine(array.ToString());
            My.TypeLine($"Сумма всех элементов массива a больше 12: {array.Sum(12)}\n");
            My.TypeLine($"Сумма всех элементов массива а: {array.Sum()}\n");
            My.TypeLine($"Номер максимального элемента массива а: {array.MaxNum(out maxNum)}\n");
            My.PauseMsg();
        }
    }
}
