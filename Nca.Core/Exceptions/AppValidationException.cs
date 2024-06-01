using System.ComponentModel.DataAnnotations;

namespace Nca.Core.Exceptions;

public class AppValidationException(IReadOnlyCollection<ValidationResult> results) 
    : AppException<IReadOnlyCollection<ValidationResult>>(results, $"Validation errors ({results.Count}).");
