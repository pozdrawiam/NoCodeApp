using Nca.Core.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Nca.Core.Cqs;

public abstract class Cmd<TCmd> : ICmd<TCmd>
{
    public async Task ExecuteAsync(TCmd cmd)
    {
        var errors = new List<ValidationResult>();

        await foreach (var error in Validate(cmd))
        {
            errors.Add(error);
        }

        if (errors.Count > 0)
        {
            throw new AppValidationException(errors);
        }
        
        await Execute(cmd);
    }

    protected abstract Task Execute(TCmd cmd);

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    protected virtual async IAsyncEnumerable<ValidationResult> Validate(TCmd cmd)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    {
        yield break;
    }
}
