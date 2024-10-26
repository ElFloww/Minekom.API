using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace Minekom.API;

/// <summary>
/// Module for API
/// </summary>
internal class ApiModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        CustomLoad(builder);
    }

    /// <summary>
    /// Custom load for all custom DI
    /// </summary>
    /// <param name="p_Builder"></param>
    private static void CustomLoad(ContainerBuilder p_Builder)
    {
        // Add here your services
        p_Builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.Name.EndsWith("Presenter"))
            .InstancePerLifetimeScope();
    }
}