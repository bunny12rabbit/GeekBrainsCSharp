using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber_HW7
{
    class Manager
    {
        int number = 0, guess;
        Random rnd = new Random();

        public Manager ()
        {
            if (this.number != 0)
            this.number = Number;
        }

        public int Number
        {
            get { return number = rnd.Next(1, 100); }
        }

        public int Guess
        {
            get {
                bool result = int.TryParse(Data.Value, out int number);
                return number;
            }
        }

        public void Check()
        {
            this.guess = Guess;
            if (number > guess)
            {
                Data.What = ">";
            }
        }

    }
}
