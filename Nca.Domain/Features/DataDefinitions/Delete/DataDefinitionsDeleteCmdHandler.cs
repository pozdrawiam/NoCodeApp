namespace Nca.Domain.Features.DataDefinitions.Delete;

public class DataDefinitionsDeleteCmdHandler(IDb db)
    : CmdHandler<DataDefinitionsDeleteCmd>
{
    protected override Task Execute(DataDefinitionsDeleteCmd cmd)
    {
        throw new NotImplementedException();
    }
}
