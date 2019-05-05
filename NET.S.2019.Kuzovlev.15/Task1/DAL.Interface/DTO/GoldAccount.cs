using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class GoldAccount : Account
    {
        public GoldAccount(string firstName, string lasttName) : base(firstName, lasttName)
        {
            Type = "Gold";
        }

        protected override void UpdateBonusPoints(decimal amount)
        {
            Points += (int)amount / 50;
        }
    }
}
