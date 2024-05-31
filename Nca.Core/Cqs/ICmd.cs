namespace Nca.Core.Cqs;

public interface ICmd<in TCmd>
{
    Task ExecuteAsync(TCmd cmd);
}
