namespace Nca.Core.Exceptions;

public class AppException(string? message = null) 
    : Exception(message);

public class AppException<TResult>(TResult result, string? message) 
    : AppException(message)
{
    public TResult Result { get; } = result;
}
