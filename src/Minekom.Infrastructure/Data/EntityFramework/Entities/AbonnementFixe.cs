using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class AbonnementFixe
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public double? Prix { get; set; }

    public int? DebitDl { get; set; }

    public int? DebitUp { get; set; }

    public virtual ICollection<AbonnementFixeUtilisateur> AbonnementFixeUtilisateurs { get; set; } = new List<AbonnementFixeUtilisateur>();
}
