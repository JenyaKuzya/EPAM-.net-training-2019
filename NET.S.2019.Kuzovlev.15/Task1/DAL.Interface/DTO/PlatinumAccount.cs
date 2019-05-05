using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class PlatinumAccount : Account
    {
        public PlatinumAccount(string firstName, string lasttName) : base(firstName, lasttName)
        {
            Type = "Platinum";
        }
        protected override void UpdateBonusPoints(decimal amount)
        {
            Points += (int)amount / 10;
        }
    }
}
