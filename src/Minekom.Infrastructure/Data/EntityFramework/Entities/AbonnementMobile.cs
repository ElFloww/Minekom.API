using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class AbonnementMobile
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public double? Prix { get; set; }

    public int? DataMax { get; set; }

    public int? TechnologieMax { get; set; }

    public virtual ICollection<AbonnementMobileUtilisateur> AbonnementMobileUtilisateurs { get; set; } = new List<AbonnementMobileUtilisateur>();

    public virtual Technologie? TechnologieMaxNavigation { get; set; }

    public virtual ICollection<TechnologieFrequence> IdTechnologieFrequences { get; set; } = new List<TechnologieFrequence>();
}
