using System;
using System.Collections.Generic;

namespace KANBAN.Data.Entity.Model;

public partial class ObjectifProjet
{
    public int IdObjectifProjet { get; set; }

    public string? DescriptionObjectif { get; set; }

    public bool? Complete { get; set; }

    public int IdProjet { get; set; }

    public virtual Projet IdProjetNavigation { get; set; } = null!;
}
