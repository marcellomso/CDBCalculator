namespace CDBCalc.Domain
{
    public class InvestmentResult
    {
        public double GrossValue { get; private set; }
        public double NetValue { get; private set; }

        public InvestmentResult(double grossValue, double NetValue)
        {
            this.GrossValue = grossValue;
            this.NetValue = NetValue;
        }
    }
}
