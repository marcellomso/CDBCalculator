namespace CDBCalc.Domain;
public class Cdb
{
    private int _deadlineRedemption;
    private double _investimentValue;

    public const int  deadlineMaxValue = 180;
    public const int deadlineMinValue = 2;

    public int DeadlineRedemption
    {
        get => _deadlineRedemption;
        set
        {
            if (value < deadlineMinValue)
                throw new DomainException($"O prazo mínimo é de {deadlineMinValue} meses");
            if (value > deadlineMaxValue)
                throw new DomainException($"O prazo máximo é de {deadlineMaxValue} meses");

            _deadlineRedemption = value;
        }
    }

    public const double valueMaxValue = 999999999999.99;
    public const double valueMinValue = 0.01;

    public double InvestimentValue
    {
        get => _investimentValue;
        set
        {
            if (value < valueMinValue)
                throw new DomainException($"O valor mínimo de investimento é R$ {valueMinValue}");
            if (value > valueMaxValue)
                throw new DomainException($"O valor máximo de investimento é R$ {valueMaxValue}");


            _investimentValue = value;
        }
    }

    public Cdb(double investimentValue, int deadlineForRedemption)
    {
        InvestimentValue = investimentValue;
        DeadlineRedemption = deadlineForRedemption;
    }

    public Cdb()
    {

    }
}
