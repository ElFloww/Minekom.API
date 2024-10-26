using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class Adresse
{
    public int Id { get; set; }

    public string? CodePostal { get; set; }

    public string? Ville { get; set; }

    public string? Rue { get; set; }

    public string? Numero { get; set; }

    public virtual ICollection<AbonnementFixeUtilisateur> AbonnementFixeUtilisateurs { get; set; } = new List<AbonnementFixeUtilisateur>();

    public virtual ICollection<Statut> IdStatuts { get; set; } = new List<Statut>();
}
