using Nca.Domain.Entities.Definitions;
using Nca.Domain.Entities.Values;

namespace Nca.Domain.Features.DataValues.Get;

public class DataValueGetQueryHandler(IDb db) 
    : IQueryHandler<DataValueGetQuery, DataValueGetQueryResult?>
{
    public async Task<DataValueGetQueryResult?> ExecuteAsync(DataValueGetQuery query)
    {
        DataValue? entity = await db.DataValues.FindAsync(query.Id);

        if (entity == null)
            return null;

        var resultValues = new Dictionary<string, string?>();

        foreach (FieldDefinition fieldDefinition in entity.DataDefinition.Fields.OrderBy(x => x.Sequence).ThenBy(x => x.Id))
        {
            FieldValue? fieldValue = entity.Fields.FirstOrDefault(x => x.FieldDefinitionId == fieldDefinition.Id);

            resultValues[fieldDefinition.Name] = fieldValue != null ? fieldValue.Value : fieldDefinition.DefaultValue;
        }

        return new DataValueGetQueryResult(resultValues);
    }
}
