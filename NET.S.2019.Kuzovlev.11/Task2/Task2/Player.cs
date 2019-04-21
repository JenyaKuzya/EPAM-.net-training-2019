using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Player
    {
        private string name;
        private int number;

        public Player(string name)
        {
            this.name = name ?? throw new ArgumentNullException();
        }

        public void Check(Roulette roulette)
        {
            if (roulette == null)
            {
                throw new ArgumentNullException(nameof(roulette) + "can't be null");
            }
        }
        public void OnOdd(Roulette roulette)
        {
            Check(roulette);
            roulette.OddNumber += ShowMessage;
            roulette.EvenNumber -= ShowMessage;
        }

        public void OnEven(Roulette roulette)
        {
            Check(roulette);
            roulette.EvenNumber += ShowMessage;
            roulette.OddNumber -= ShowMessage;
        }

        public void OnRed(Roulette roulette)
        {
            Check(roulette);
            roulette.RedNumber += ShowMessage;
            roulette.BlackNumber -= ShowMessage;
        }

        public void OnBlack(Roulette roulette)
        {
            Check(roulette);
            roulette.BlackNumber += ShowMessage;
            roulette.RedNumber -= ShowMessage;
        }

        public void OnNumber(Roulette roulette, int value)
        {
            Check(roulette);

            if (value < 0 || value > 36)
            {
                throw new ArgumentException(nameof(roulette) + "can't be less than 0 and more than 36");
            }

            this.number = value;
            roulette.OnNumber += ShowMessageOnNumber;
        }

        public void ShowMessage(object sender, EventArgs e)
        {
            Console.WriteLine("You won:" + name);
        }

        public void ShowMessageOnNumber(object sender, RouletteEventArgs e)
        {
            if (number == e.Number)
            {
                Console.WriteLine("You won:" + name);
            }
        }
    }
}
