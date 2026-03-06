using CleanTeeth.Domain.Exceptions;
namespace CleanTeeth.Domain.ValueObjects;

internal class TimeInterval
{
    //inmutable sin set que no se pueda cambiar
    public DateTime Start {  get; }
    public DateTime End { get; }

    public TimeInterval(DateTime start, DateTime end)
    {
        if(start > end)
        {
            throw new BusinessRuleException($"La fecha de inicio no puede ser posterior a la de finalización");
        }
    }
}
