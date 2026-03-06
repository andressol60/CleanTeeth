using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
namespace CleanTeeth.Domain.Entities;

public class Patient
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;

    public Patient(string name, string email)
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


