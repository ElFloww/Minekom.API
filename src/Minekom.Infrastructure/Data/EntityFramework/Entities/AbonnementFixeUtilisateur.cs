using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class AbonnementFixeUtilisateur
{
    public int Id { get; set; }

    public int? IdAbonnementFixe { get; set; }

    public int? IdAdresse { get; set; }

    public int? IdUtilisateur { get; set; }

    public virtual AbonnementFixe? IdAbonnementFixeNavigation { get; set; }

    public virtual Adresse? IdAdresseNavigation { get; set; }

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; }
}
