using System.ComponentModel.DataAnnotations;

namespace Nca.Core.Utils;

public static class Validation
{
    private const string InvalidValueMsg = "Invalid value";
    
    public static ValidationResult ResultFromMember(params string[] members) 
        => new(InvalidValueMsg, members);
}
