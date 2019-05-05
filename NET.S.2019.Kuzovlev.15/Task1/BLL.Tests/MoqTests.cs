using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using NUnit.Framework;
using Moq;

namespace BLL.Tests
{
    [TestFixture]
    public class BllMoqTests
    {
        [TestCase]
        public void Get_Accounts_Test()
        {
            var moq = new Mock<IStorage>();
            moq.Setup(a => a.Accounts).Returns(new List<Account>());

            IService service = new AccountService(moq.Object);

            var accounts = service.GetAllAccounts();

            Assert.IsNotNull(accounts);
        }

        [TestCase]
        public void Add_Wrong_Data_Account_Test()
        {
            var moq = new Mock<IStorage>();
            moq.Setup(a => a.Add("Basic", "", "")).Throws(new ArgumentNullException());

            IService service = new AccountService(moq.Object);

            Assert.Throws<ArgumentNullException>(() => service.CreateAccount(AccountType.Basic, "", ""));
        }
    }
}
