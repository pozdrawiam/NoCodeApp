using Microsoft.EntityFrameworkCore;
using Nca.Core.Cqs;
using Nca.Core.Utils;
using Nca.Domain.Entities;
using Nca.Domain.Entities.Values;
using System.ComponentModel.DataAnnotations;

namespace Nca.Domain.Features.DataValues.Add;

public class DataValueAddCmdHandler(IDb db) : Cmd<DataValueAddCmd>
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
        {
            yield return Validation.ResultFromMember(nameof(cmd.DataDefinitionId));
        }
    }
}
