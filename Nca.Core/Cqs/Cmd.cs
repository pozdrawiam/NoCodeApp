using System.ComponentModel.DataAnnotations;

namespace Nca.Core.Cqs;

public abstract class Cmd<TCmd> : ICmd<TCmd>
{
    public async Task ExecuteAsync(TCmd cmd)
    {
        await Validate(cmd);
        await Execute(cmd);
    }

    protected abstract Task Execute(TCmd cmd);

    protected virtual async Task<IEnumerable<ValidationResult>> Validate(TCmd cmd)
    {
        return await Task.FromResult(Array.Empty<ValidationResult>());
    }
}
