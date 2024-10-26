using Autofac;
using Minekom.Domain.Interfaces.Data;
using Minekom.Domain.Interfaces.Token;
using Minekom.Infrastructure.Data;
using Minekom.Infrastructure.Data.EntityFramework;
using Minekom.Infrastructure.Jwt;
using System.Diagnostics.CodeAnalysis;

namespace Minekom.Infrastructure;

public class InfrastructureModule : Module
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
        p_Builder.RegisterType<UnitOfWork<MinekomContext>>()
                 .As<IUnitOfWork>()
                 .InstancePerLifetimeScope();
        p_Builder.RegisterType<JwtFactory>()
                 .As<IJwtFactory>()
                 .InstancePerLifetimeScope();
    }
}