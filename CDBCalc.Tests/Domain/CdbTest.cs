using CDBCalc.Domain;

namespace CDBCalc.Tests.Domain
{
    [TestFixture]
    public class CdbTest
    {
        private readonly int deadline = 7;
        private readonly double value = 100.99;

        [Test]
        public void ShoudAcceptValidValueConstructor()
        {
            var cdb = new Cdb(value, deadline);
            Assert.Multiple(() =>
            {
                Assert.That(value, Is.EqualTo(cdb.InvestimentValue));
                Assert.That(deadline, Is.EqualTo(cdb.DeadlineRedemption));
            });
        }

        [Test]
        public void ShoudNotAcceptInvalidValue()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<DomainException>(() => new Cdb(Cdb.valueMinValue -1, deadline));
                Assert.Throws<DomainException>(() => new Cdb(Cdb.valueMaxValue + 1, deadline));
            });
        }

        [Test]
        public void ShoudNotAcceptInvalidDeadline()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<DomainException>(() => new Cdb(value, Cdb.deadlineMinValue - 1));
                Assert.Throws<DomainException>(() => new Cdb(value, Cdb.deadlineMaxValue + 1));
            });
        }
    }
}
