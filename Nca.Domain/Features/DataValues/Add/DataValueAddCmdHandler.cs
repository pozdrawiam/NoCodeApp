using Microsoft.EntityFrameworkCore;
using Nca.Core.Cqs;
using Nca.Domain.Entities.Values;

namespace Nca.Domain.Features.DataValues.Add;

public class DataValueAddCmdHandler(IDb db) : CmdHandler<DataValueAddCmd>
{
    protected override async Task Execute(DataValueAddCmd cmd)
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

    protected override async IAsyncEnumerable<ValidationResult> Validate(DataValueAddCmd cmd)
    {
        if (!await db.DataDefinitions.AnyAsync(x => x.Id == cmd.DataDefinitionId))
            yield return Validation.ResultFromMember(nameof(cmd.DataDefinitionId));
        
        if (cmd.Fields.Count == 0)
            yield return Validation.ResultFromMember(nameof(cmd.Fields));
        else
        {
            for (var i = 0; i < cmd.Fields.Count; i++)
            {
                var field = cmd.Fields[i];
                
                if (!await db.FieldDefinitions.AnyAsync(x => x.Id == field.FieldDefinitionId))
                    yield return Validation.ResultFromMember($"{nameof(cmd.DataDefinitionId)}[{i}]");
            }
        }
    }
}
