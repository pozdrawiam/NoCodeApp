using Nca.Domain.Entities;
using Nca.Domain.Entities.Values;

namespace Nca.Domain.Features.DataValues.Add;

public class DataValueAddCmdHandler(IDb db)
{
    public async Task ExecuteAsync(DataValueAddCmd cmd)
    {
        var entity = new DataValue
        {
            DataDefinitionId = cmd.DataDefinitionId,
            Fields = cmd.Fields.Select(x => new FieldValue
            {
                FieldDefinitionId = x.FieldDefinitionId,
                Value = x.Value
            }).ToList()
        };

        db.DataValues.Add(entity);

        await db.SaveChangesAsync();
    }
}
