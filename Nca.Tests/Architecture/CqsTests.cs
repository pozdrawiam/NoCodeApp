using System.Reflection;
using Nca.Core.Cqs;

namespace Nca.Tests.Architecture;

public class CqsTests
{
    private const string DomainAssemblyName = "Nca.Domain";

    [Fact]
    public void Cmd_handlers_should_implement_interface()
    {
        var assembly = Assembly.Load(DomainAssemblyName);
        var cmdHandlerTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("CmdHandler")).ToArray();

        foreach (var type in cmdHandlerTypes)
        {
            var iType = type.GetInterfaces().FirstOrDefault(x => x.Name.Contains(nameof(ICmdHandler<object>)));

            if (iType == null)
                Assert.Fail($"No interface '{nameof(ICmdHandler<object>)}' for cmd handler '{type.Name}'");

            if (!iType.IsGenericType)
                Assert.Fail($"$Type '{iType.Name}' is not generic in cmd handler '{type.Name}'");

            var gType = iType.GetGenericTypeDefinition().GetGenericArguments()[0];

            if (!gType.Name.EndsWith("Cmd"))
                Assert.Fail($"Invalid Cmd type name: '{type.Name} : {iType.Name}<{gType.Name}>'");
        }

        Assert.NotEmpty(cmdHandlerTypes);
    }

    [Fact]
    public void Cmd_handlers_name_should_valid_suffix()
    {
        var assembly = Assembly.Load(DomainAssemblyName);
        var cmdHandlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && typeof(ICmdHandler<>) == i.GetGenericTypeDefinition()))
            .ToArray();

        foreach (var type in cmdHandlerTypes)
        {
            if (!type.Name.EndsWith("CmdHandler"))
                Assert.Fail($"Invalid name suffix for cmd handler '{type.Name}'");
        }
        
        Assert.NotEmpty(cmdHandlerTypes);
    }

    [Fact]
    public void Query_handlers_should_implement_interface()
    {
        var assembly = Assembly.Load(DomainAssemblyName);
        var queryHandlerTypes = assembly.GetTypes().Where(t => t.Name.EndsWith("QueryHandler")).ToArray();

        foreach (var type in queryHandlerTypes)
        {
            var iType = type.GetInterfaces()
                .FirstOrDefault(x => x.Name.Contains(nameof(IQueryHandler<object, object>)));

            if (iType == null)
                Assert.Fail($"No interface '{nameof(IQueryHandler<object, object>)}' for query handler '{type.Name}'");

            if (!iType.IsGenericType)
                Assert.Fail($"$Type '{iType.Name}' is not generic in query handler '{type.Name}'");

            var gArgs = iType.GetGenericTypeDefinition().GetGenericArguments();
            var queryType = gArgs[0];

            if (!queryType.Name.EndsWith("Query"))
                Assert.Fail($"Invalid Query type name: '{type.Name} : {iType.Name}<{queryType.Name}, ...>'");

            var resultType = gArgs[1];

            if (!resultType.Name.EndsWith("Result"))
            {
                Assert.Fail($"Invalid Query type name: '{type.Name} : {iType.Name}<{queryType.Name}, {resultType.Name}>'");
            }
        }

        Assert.NotEmpty(queryHandlerTypes);
    }
}
