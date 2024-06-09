using Nca.Domain.Entities.Definitions;

namespace Nca.Domain.Features.DataDefinitions.Delete;

public class DataDefinitionsDeleteCmdHandler(IDb db)
    : CmdHandler<DataDefinitionsDeleteCmd>
{
    protected override async Task Execute(DataDefinitionsDeleteCmd cmd)
    {
        int[] ids = cmd.Ids.Distinct().ToArray();
        IQueryable<DataDefinition> definitions = db.DataDefinitions.Where(x => ids.Contains(x.Id));

        db.DataDefinitions.RemoveRange(definitions);

        await db.SaveChangesAsync();
    }
}
