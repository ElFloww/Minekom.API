﻿using Autofac;
using Minekom.Core.Configuration;
using Minekom.Domain.Configuration;

namespace Minekom.Core;

/// <summary>
/// Module for Core
/// </summary>
public class CoreModule : Module
{
    [SuppressMessage("Style", "IDE1006:Styles d'affectation de noms", Justification = "Inherited named")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
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
        p_Builder.RegisterConfiguration<WebsiteConfiguration>();
    }
}