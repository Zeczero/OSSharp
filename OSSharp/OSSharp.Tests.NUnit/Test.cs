using NUnit.Framework;
using OSSharp.Core.Clients;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OSSharp.Tests.NUnit
{
    public class Tests
    {
        private User _user;
        private SMSReception reception;

        [SetUp]
        public void Setup()
        {
            _user = new User(new HttpClient(), "");
            reception = new SMSReception(new HttpClient(), "");
        }

        [Test]
        public async Task GetUserAccountBalance()
        {
            var result = await _user.GetBalance();

            Assert.AreEqual("3.97", result.Balance);
        }

        [Test]
        public async Task GetUserAccountZBalance()
        {
            var result = await _user.GetBalance();

            Assert.AreEqual(0, result.Zbalance);
        }
        [Test]
        public async Task GetNumberCostByService()
        {
            var result = await reception.GetNumberStatistics("telegram");

            Assert.AreEqual(0.64, result.Price);
        }
        [Test]
        public async Task GetNumberCostByCountryCode()
        {
            var result = await reception.GetNumberStatistics(48);

            Assert.AreEqual(48, result.Code);
        }
        
        [Test]
        public async Task OrderVirtualNumber()
        {
            var result = await reception.OrderNumber("vkcom");

            Assert.AreEqual(1, result.Response);
        }

        [Test]
        public async Task GetOrderStatus()
        {
            var result = await reception.GetOrderState();

            Assert.AreEqual("vkcom", result[0].Service);
        }

    }
}