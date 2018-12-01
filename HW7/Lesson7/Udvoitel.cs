using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    //    а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    //б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.Игрок должен получить это число за минимальное количество ходов.
    //в) * Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте обобщенный класс Stack.
    // Вся логика игры должна быть реализована в классе с удвоителем.
    //Романенко Андрей Григорьевич
    class Udvoitel
    {
        int current;
        int finish;
        int counter = 0;
        Stack<int> history = new Stack<int>();
        StatusGame statusGame;

        enum StatusGame
        {
            Game, Win, Lose
        }

        public int Current
        {
            get { return current; }
        }

        public int Finish
        {
            get { return finish; }
        }

        public int Counter
        {
            get { return counter; }
        }

        public int CounterPlus()
        {
            return counter++;
        }


        public int History
        {
            get
            {
                if (history.Count > 1)
                {
                    history.Pop();
                    current = history.Peek();
                }
                return current;
            }
            
        }

        public Udvoitel(int finish)
        {
            this.finish = finish;
            current = 1;
        }

        public void Plus()
        {
            current++;
            history.Push(current);
        }

        public void Multi()
        {
            current *= 2;
            history.Push(current);
        }

        public void Reset()
        {
            current = 1;
            history.Clear();
            counter = 0;
        }

    }
}
