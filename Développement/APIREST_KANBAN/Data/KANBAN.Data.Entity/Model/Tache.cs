using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KANBAN.Data.Entity.Model;

public partial class Tache
{
    public int IdTache { get; set; }

    public string TitreTache { get; set; } = null!;

    public string? DescriptionTache { get; set; }

    public DateTime? DateCreation { get; set; }

    public DateTime? DateLimite { get; set; }

    public int IdUtilisateur { get; set; }

    public int IdStatut { get; set; }

    public int IdProjet { get; set; }
    [JsonIgnore]
    public virtual ICollection<ActionTache> ActionTaches { get; set; } = new List<ActionTache>();
    [JsonIgnore]
    public virtual Projet IdProjetNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Statut IdStatutNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Utilisateur IdUtilisateurNavigation { get; set; } = null!;
}
