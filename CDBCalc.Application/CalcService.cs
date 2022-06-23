using CDBCalc.Domain;

namespace CDBCalc.Application
{
    public class CalcService : ICalcService
    {
        private const double tb = 1.08;
        private const double cdi = 0.009;

        public InvestmentResult Calculate(Cdb data)
        {
            var grossIncome = CalcGrossValue(data);
            var taxRate = GetTaxRate(data.DeadlineRedemption);
            var netIncome = CalcNetValue(grossIncome, data.InvestimentValue, taxRate);
            return new InvestmentResult(grossIncome, netIncome);
        }

        public static double GetTaxRate(int months)
        {
            if (months < 7) return 0.225;
            if (months < 13) return 0.2;
            if (months < 25) return 0.175;
            return 0.15;
        }

        private static double CalcGrossValue(Cdb data)
        {
            double vf = 0;
            double vi = data.InvestimentValue;

            for (int m = 0; m < data.DeadlineRedemption; m++)
            {
                vf = vi * (1 + cdi * tb);
                vi = vf;
            }

            return vf;
        }

        private static double CalcNetValue(double grossValue, double vi, double taxRate)
        {
            var profit = grossValue - vi;
            var tax = profit * taxRate;
            return grossValue - tax;
        }
    }
}
