using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public enum AccountStatus
    {
        Active,
        Close
    }

    [Serializable]
    public abstract class Account
    {
        private static int currId = 1000000;

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Type { get; protected set; }
        public decimal Balance { get; private set; }
        public int Points { get; protected set; }
        public AccountStatus Status { get; set; }

        public Account(string ownerFirstName, string ownerLastName)
        {
            if (ownerFirstName == null || ownerLastName == null)
            {
                throw new ArgumentNullException("Names can't be null");
            }

            if (ownerFirstName.Length == 0 || ownerLastName.Length == 0)
            {
                throw new ArgumentException("Names can't be empty");
            }

            Id = GetId();
            FirstName = ownerFirstName;
            LastName = ownerLastName;
            Balance = 0;
            Points = 0;
            Status = AccountStatus.Active;
        }

        public Account()
        {
        }

        public override string ToString()
        {
            return "Account №" + Id + "\n Owner: " + FirstName + " " + LastName + " \n Amount: " + Balance + "$  points:" + Points + "\n Status: " + Status + "  Type: " + Type;
        }

        private int GetId()
        {
            return ++currId;

            //Random rnd = new Random();
            //return rnd.Next(1000000, 10000000);
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            Balance += amount;
            UpdateBonusPoints(amount);
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            if (Balance - amount < 0)
            {
                throw new ArgumentException("Balance can't be negetive");
            }

            Balance -= amount;
            UpdateBonusPoints(amount);
        }

        protected abstract void UpdateBonusPoints(decimal amount);
    }
}
