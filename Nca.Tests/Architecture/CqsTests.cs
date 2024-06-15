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
                Assert.Fail($"No interface {nameof(ICmdHandler<object>)} for cmd handler {type.Name}");
            
            if (!iType.IsGenericType)
                Assert.Fail($"$Type {iType.Name} is not generic in cmd handler {type.Name}");
            
            var gType = iType.GetGenericTypeDefinition().GetGenericArguments()[0];

            if (!gType.Name.EndsWith("Cmd"))
                Assert.Fail($"Invalid Cmd type name: {type.Name} : {iType.Name}<{gType.Name}>");
        }
        
        Assert.NotEmpty(cmdHandlerTypes);
    }
}
