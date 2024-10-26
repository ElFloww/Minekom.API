using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class Technologie
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<AbonnementMobile> AbonnementMobiles { get; set; } = new List<AbonnementMobile>();

    public virtual ICollection<TechnologieFrequence> TechnologieFrequences { get; set; } = new List<TechnologieFrequence>();
}
