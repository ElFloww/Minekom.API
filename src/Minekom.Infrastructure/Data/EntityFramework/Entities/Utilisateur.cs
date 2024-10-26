using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class Utilisateur
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public DateOnly? DateDeNaissance { get; set; }

    public string? Email { get; set; }

    public string? MotDePasse { get; set; }

    public string? Telephone { get; set; }

    public virtual ICollection<AbonnementFixeUtilisateur> AbonnementFixeUtilisateurs { get; set; } = new List<AbonnementFixeUtilisateur>();

    public virtual ICollection<AbonnementMobileUtilisateur> AbonnementMobileUtilisateurs { get; set; } = new List<AbonnementMobileUtilisateur>();
}
