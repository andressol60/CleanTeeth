using CleanTeeth.Domain.Exceptions;

namespace CleanTeeth.Domain.Entities;

public class DentalOffice
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;

    public DentalOffice(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            //throw new ArgumentNullException($"nameof(name) es requerido");
            throw new BusinessRuleException($"El {nameof(name)} es obligatorio");
        }

        Name = name;
        //La v7 de guid cambia el algoritmo de generacion de guid
        Id = Guid.CreateVersion7();
    }
}
