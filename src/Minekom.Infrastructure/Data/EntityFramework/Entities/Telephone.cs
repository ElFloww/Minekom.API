using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class Telephone
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Marque { get; set; }

    public double? Prix { get; set; }

    public virtual ICollection<AbonnementMobileUtilisateur> AbonnementMobileUtilisateurs { get; set; } = new List<AbonnementMobileUtilisateur>();

    public virtual ICollection<TechnologieFrequence> IdTechnologieFrequences { get; set; } = new List<TechnologieFrequence>();
}
