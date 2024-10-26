﻿using Minekom.Domain.Configuration;

namespace Minekom.Core.Configuration;

public class WebsiteConfiguration : AServiceConfiguration
{
    public const string SECTIONNAME = "Website";
    public string BaseUri { get; set; } = string.Empty;

    public override string GetSectionName() => SECTIONNAME;
}