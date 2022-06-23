using CDBCalc.Domain;

namespace CDBCalc.Application
{
    public interface ICalcService
    {
        InvestmentResult Calculate(Cdb data);
    }
}
