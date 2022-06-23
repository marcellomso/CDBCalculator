using CDBCalc.Application;
using CDBCalc.Domain;

namespace CDBCalc.Tests.Application
{
    [TestFixture]
    public class CalcServiceTest
    {
        private readonly CalcService _service;
        private double iv;
        private double tax;
        private int month;

        public CalcServiceTest()
        {
            _service = new CalcService();
            iv = 1797.97;
        }

        [Test]
        public void ShouldCalculateValidValueFor6Months()
        {
            month = 6;
            tax = CalcService.GetTaxRate(month);
            var data = new Cdb(iv, month);
            var result = _service.Calculate(data);

            Assert.Multiple(() =>
            {
                Assert.That(tax, Is.EqualTo(0.225));
                Assert.That(Math.Round(result.GrossValue, 2), Is.EqualTo(1905.41));
                Assert.That(Math.Round(result.NetValue, 2), Is.EqualTo(1881.24));
            });
        }

        [Test]
        public void ShouldCalculateValidValueFor11Months()
        {
            month = 11;
            tax = CalcService.GetTaxRate(month);
            var data = new Cdb(iv, month);
            var result = _service.Calculate(data);

            Assert.Multiple(() =>
            {
                Assert.That(tax, Is.EqualTo(0.2));
                Assert.That(Math.Round(result.GrossValue, 2), Is.EqualTo(1999.83));
                Assert.That(Math.Round(result.NetValue, 2), Is.EqualTo(1959.46));
            });
        }

        [Test]
        public void ShouldCalculateValidValueFor21Months()
        {
            month = 21;
            tax = CalcService.GetTaxRate(month);
            var data = new Cdb(iv, month);
            var result = _service.Calculate(data);

            Assert.Multiple(() =>
            {
                Assert.That(tax, Is.EqualTo(0.175));
                Assert.That(Math.Round(result.GrossValue, 2), Is.EqualTo(2202.94));
                Assert.That(Math.Round(result.NetValue, 2), Is.EqualTo(2132.07));
            });
        }

        [Test]
        public void ShouldCalculateValidValueFor31Months()
        {
            month = 31;
            tax = CalcService.GetTaxRate(month);
            var data = new Cdb(iv, month);
            var result = _service.Calculate(data);

            Assert.Multiple(() =>
            {
                Assert.That(tax, Is.EqualTo(0.15));
                Assert.That(Math.Round(result.GrossValue, 2), Is.EqualTo(2426.68));
                Assert.That(Math.Round(result.NetValue, 2), Is.EqualTo(2332.37));
            });
        }
    }
}
