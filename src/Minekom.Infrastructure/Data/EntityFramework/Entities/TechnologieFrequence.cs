using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class TechnologieFrequence
{
    public int Id { get; set; }

    public int IdFrequence { get; set; }

    public int IdTechnologie { get; set; }

    public int MaxDl { get; set; }

    public int MaxUp { get; set; }

    public virtual Frequence IdFrequenceNavigation { get; set; } = null!;

    public virtual Technologie IdTechnologieNavigation { get; set; } = null!;

    public virtual ICollection<AbonnementMobile> IdAbonnementMobiles { get; set; } = new List<AbonnementMobile>();

    public virtual ICollection<Antenne> IdAntennes { get; set; } = new List<Antenne>();

    public virtual ICollection<Telephone> IdTelephones { get; set; } = new List<Telephone>();
}
