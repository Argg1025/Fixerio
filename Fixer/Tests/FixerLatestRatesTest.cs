using System;
using NUnit.Framework;
using Fixer.FixerLatestServices;

namespace Fixer.Tests
{
    [TestFixture]
    public class FixerLatestRatesTest
    {
        private FixerLatestServices.FixerLatestService fixerLatestRates = new FixerLatestServices.FixerLatestService();
        [Test]
        public void WebCallSuccessCheck()
        {
            Assert.AreEqual(true, fixerLatestRates.fixerLatestDTO.LatestRates.success);
        }

        [Test]
        public void TotalRatesCheck()
        {
            Assert.AreEqual(168, fixerLatestRates.RatesCount());
        }

        [Test]
        public void AllRatesFloats()
        {
            Assert.AreEqual(true, fixerLatestRates.CheckFloats());
        }

        [Test]
        public void BaseCheck()
        {
            Assert.AreEqual("1", fixerLatestRates.LatestRatesJson["rates"][$"{fixerLatestRates.LatestRatesJson["base"]}"].ToString());
        }

        [Test]
        public void CheckDate()
        {
            Assert.AreEqual(DateTime.Now.ToString("yyyy-MM-dd"), fixerLatestRates.fixerLatestDTO.LatestRates.date);
        }

        [Test]
        public void CheckTimeStampNotMaxDate()
        {
            Assert.LessOrEqual(DateTimeOffset.FromUnixTimeSeconds(fixerLatestRates.fixerLatestDTO.LatestRates.timestamp)
        .DateTime.ToLocalTime(), DateTime.Parse("03:14:07 19 January 2038"));
            Assert.AreEqual(typeof(int), fixerLatestRates.fixerLatestDTO.LatestRates.timestamp.GetType());
        }


        // Total rates check
        // All rates are floats
        // Base check if it is 1
        // Date
        // Timestamp check
    }
}
