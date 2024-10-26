using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class Frequence
{
    public int Id { get; set; }

    public int? Label { get; set; }

    public int? Portee { get; set; }

    public virtual ICollection<TechnologieFrequence> TechnologieFrequences { get; set; } = new List<TechnologieFrequence>();
}
