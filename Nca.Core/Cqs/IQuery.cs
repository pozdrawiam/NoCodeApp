namespace Nca.Core.Cqs;

public interface IQuery<in TQuery, TResult>
{
    Task<TResult> ExecuteAsync(TQuery query);
}
