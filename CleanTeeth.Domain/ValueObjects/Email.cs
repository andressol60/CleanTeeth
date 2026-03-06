using CleanTeeth.Domain.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace CleanTeeth.Domain.ValueObjects;

public sealed class Email
{
    public string Value { get; } = null!;

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleException($"El {nameof(email)} es obligatorio");
        }

        //TODO: Averiguar como validar correctamente un correo nombre@gmail.com
        if (email.Contains("@"))
        {
            throw new BusinessRuleException($"El {nameof(email)} no es valido");
        }
        Value = email;
    }

}
