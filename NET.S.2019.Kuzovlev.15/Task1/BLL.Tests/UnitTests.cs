using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using BLL.ServiceImplementation;
using DAL.Repositories;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class NUnitTests
    {
        [Test]
        public void Bll_CreateNew_Account()
        {
            IService service = new AccountService(new AccountStorage());

            service.CreateAccount(AccountType.Basic, "Maxim", "Markin");
            var actual = service.GetAllAccounts();
            int expected = 1;

            Assert.AreEqual(expected, actual.Count);
        }

        [Test]
        public void Bll_CreateNew_Wrong_Name_Account()
        {
            IService service = new AccountService(new AccountStorage());

            Assert.Throws<ArgumentNullException>(() => service.CreateAccount(AccountType.Basic, "", "Markin"));
        }

        [Test]
        public void Bll_CreateNew_Wrong_LastName_Account()
        {
            IService service = new AccountService(new AccountStorage());

            Assert.Throws<ArgumentNullException>(() => service.CreateAccount(AccountType.Basic, "Max", ""));
        }

        [Test]
        public void Bll_Delete_Account()
        {
            IService service = new AccountService(new AccountStorage());

            service.CreateAccount(AccountType.Basic, "Maxim", "Markin");
            service.CloseAccount(1000001);
            var actual = service.GetAllAccounts();
            int expected = 0;

            Assert.AreEqual(expected, actual.Count);
        }

        [Test]
        public void Bll_Delete_Wrong_Id_Account()
        {
            IService service = new AccountService(new AccountStorage());

            service.CreateAccount(AccountType.Basic, "Maxim", "Markin");



            Assert.Throws<ArgumentException>(() => service.CloseAccount(1000010));
        }

    }
}
