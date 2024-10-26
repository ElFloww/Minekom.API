using System;
using System.Collections.Generic;

namespace Minekom.Infrastructure.Data.EntityFramework.Entities;

public partial class Statut
{
    public int Id { get; set; }

    public string? Statut1 { get; set; }

    public virtual ICollection<Adresse> IdAdresses { get; set; } = new List<Adresse>();
}
