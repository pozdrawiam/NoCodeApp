namespace Nca.Core.Cqs;

public interface ICmdHandler<in TCmd>
{
    Task ExecuteAsync(TCmd cmd);
}
