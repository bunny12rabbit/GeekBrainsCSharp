using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMethods;
using _2DimenArray;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            My.TypeLine("Введите размернсть массива: ");
            int n = My.ForceReadInteger();
            TwoDimenArray array = new TwoDimenArray(n, 0, 10);
            int max = array.Max;
            My.TypeLine($"Массив а:\n" +
                $"{array.ToString()}");
            My.TypeLine($"\nМаксимальное значение массива а: {array.Max}");
            My.Pause();
        }
    }
}
