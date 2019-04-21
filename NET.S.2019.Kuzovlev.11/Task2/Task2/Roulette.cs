using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Roulette
    {
        public event EventHandler OddNumber;
        public event EventHandler EvenNumber;
        public event EventHandler RedNumber;
        public event EventHandler BlackNumber;
        public event EventHandler<RouletteEventArgs> OnNumber;

        private enum Color
        {
            red,
            black
        }

        public void PlayRound()
        {
            Random random = new Random();
            int result = random.Next(37);

            Color color = (Color)random.Next(0, 1);

            if (color == Color.red)
            {
                RedWins();
            }
            else
            {
                BlackWins();
            }

            if (result % 2 == 1)
            {
                OddWins();
            }
            else
            {
                EvenWins();
            }

            NumberWins(new RouletteEventArgs(result));
        }

        private void RedWins()
        {
            RedNumber?.Invoke(this, new EventArgs());
        }

        private void BlackWins()
        {
            BlackNumber?.Invoke(this, new EventArgs());
        }

        private void OddWins()
        {
            OddNumber?.Invoke(this, new EventArgs());
        }

        private void EvenWins()
        {
            EvenNumber?.Invoke(this, new EventArgs());
        }

        private void NumberWins(RouletteEventArgs e)
        {
            OnNumber?.Invoke(this, e);
        }       
    }
}
