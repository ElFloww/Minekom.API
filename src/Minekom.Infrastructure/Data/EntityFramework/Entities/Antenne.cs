using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class Antenne
{
    public int Id { get; set; }

    public int? X { get; set; }

    public int? Y { get; set; }

    public int? Z { get; set; }

    public virtual ICollection<TechnologieFrequence> IdTechnologieAntennes { get; set; } = new List<TechnologieFrequence>();
}
