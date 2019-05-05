using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DAL.Repositories
{
    public class AccountStorage : IStorage
    {
        private static List<Account> accounts = new List<Account>();

        public List<Account> Accounts { get { return accounts; } }

        public void Add(string accountType, string name, string lastname)
        {
            switch (accountType)
            {
                case "Basic":
                    accounts.Add(new BaseAccount(name, lastname));
                    break;
                case "Gold":
                    accounts.Add(new GoldAccount(name, lastname));
                    break;
                case "Platinum":
                    accounts.Add(new PlatinumAccount(name, lastname));
                    break;
            }
        }

        public void Remove(int id)
        {
            Account account = GetByID(id);

            if (account == null)
            {
                throw new ArgumentException("Account not exist");
            }

            accounts.Remove(account);
        }

        public void SaveAccounts(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, accounts);
            }
        }

        public void LoadAccounts(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                List<Account> listnew = (List<Account>)formatter.Deserialize(fs);

                accounts = listnew;
            }
        }

        public Account GetByID(int id)
        {
            if (accounts.Count == 0)
            {
                return null;
            }

            foreach (Account account in accounts)
            {
                if (account.Id == id)
                {
                    return account;
                }
            }

            return null;
        }
    }
}
