using System;
using System.Collections.Generic;

namespace KANBAN.Data.Entity.Model;

public partial class ActionTache
{
    public int IdActionTache { get; set; }

    public string? DescriptionAction { get; set; }

    public int IdTache { get; set; }

    public bool? Complete { get; set; }

    public virtual Tache IdTacheNavigation { get; set; } = null!;
}
