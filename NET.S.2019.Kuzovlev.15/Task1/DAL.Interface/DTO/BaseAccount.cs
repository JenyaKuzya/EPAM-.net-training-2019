using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    [Serializable]
    public class BaseAccount : Account
    {
        public BaseAccount(string firstName, string lasttName) : base(firstName, lasttName)
        {
            Type = "Base";
        }

        protected override void UpdateBonusPoints(decimal amount)
        {
            Points += (int)amount / 100;
        }
    }
}
