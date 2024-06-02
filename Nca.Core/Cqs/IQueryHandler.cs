namespace Nca.Core.Cqs;

public interface IQueryHandler<in TQuery, TResult>
{
    Task<TResult> ExecuteAsync(TQuery query);
}
