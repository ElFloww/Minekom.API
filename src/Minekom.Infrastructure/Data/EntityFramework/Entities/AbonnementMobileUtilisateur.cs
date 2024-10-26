using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class AbonnementMobileUtilisateur
{
    public int Id { get; set; }

    public int? IdAbonnementMobile { get; set; }

    public int? IdUtilisateur { get; set; }

    public int? IdTelephone { get; set; }

    public virtual AbonnementMobile? IdAbonnementMobileNavigation { get; set; }

    public virtual Telephone? IdTelephoneNavigation { get; set; }

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; }
}
